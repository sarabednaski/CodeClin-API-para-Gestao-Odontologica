using codeclin.Application.Service;
using codeclin.DataContext;
using codeclin.Domain.Interfaces;
using codeclin.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using codeclin.MappingProfile;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<PacienteService>();

builder.Services.AddScoped<IDentistaRepository, DentistaRepository>();
builder.Services.AddScoped<DentistaService>();

builder.Services.AddScoped<IConsultaRepository, ConsultaRepository>();
builder.Services.AddScoped<ConsultaService>();

builder.Services.AddScoped<IPagamentoRepository, PagamentoRepository>();
builder.Services.AddScoped<PagamentoService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();