using codeclin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace codeclin.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Dentista> Dentistas { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurando os relacionamentos no banco de dados
            modelBuilder.Entity<Consulta>()
                .HasOne(c => c.Paciente)
                .WithMany(p => p.Consultas)
                .HasForeignKey(c => c.PacienteId);

            modelBuilder.Entity<Consulta>()
                .HasOne(c => c.Dentista)
                .WithMany(d => d.Consultas)
                .HasForeignKey(c => c.DentistaId);

            modelBuilder.Entity<Pagamento>()
                .HasOne(p => p.Consulta)
                .WithOne()
                .HasForeignKey<Pagamento>(p => p.ConsultaId);
        }
    }
}
