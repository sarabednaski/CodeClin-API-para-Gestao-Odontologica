using codeclin.DataContext;
using codeclin.Domain.Entities;
using codeclin.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace codeclin.Infrastructure.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly ApplicationDbContext _context;

        public ConsultaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Consulta>> GetAllAsync() => await _context.Consultas.ToListAsync();
        public async Task<Consulta> GetByIdAsync(int id) => await _context.Consultas.FindAsync(id);

        public async Task AddAsync(Consulta consulta)
        {
            await _context.Consultas.AddAsync(consulta);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Consulta consulta)
        {
            _context.Consultas.Update(consulta);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);
            if (consulta != null)
            {
                _context.Consultas.Remove(consulta);
                await _context.SaveChangesAsync();
            }
        }
    }
}
