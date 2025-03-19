using codeclin.DataContext;
using codeclin.Domain.Entities;
using codeclin.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace codeclin.Infrastructure.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly ApplicationDbContext _context;

        public PacienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Paciente>> ObterTodosAsync()
        {
            return await _context.Pacientes.ToListAsync();
        }

        public async Task<Paciente> ObterPorIdAsync(int id)
        {
            return await _context.Pacientes.FindAsync(id);
        }

        public async Task AdicionarAsync(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Paciente paciente)
        {
            _context.Pacientes.Update(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente != null)
            {
                _context.Pacientes.Remove(paciente);
                await _context.SaveChangesAsync();
            }
        }
    }
}
