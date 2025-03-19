using codeclin.DataContext;
using codeclin.Domain.Entities;
using codeclin.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace codeclin.Infrastructure.Repositories
{
    public class DentistaRepository : IDentistaRepository
    {
        private readonly ApplicationDbContext _context;

        public DentistaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dentista>> GetAllAsync() => await _context.Dentistas.ToListAsync();
        public async Task<Dentista> GetByIdAsync(int id) => await _context.Dentistas.FindAsync(id);
        public async Task AddAsync(Dentista dentista)
        {
            await _context.Dentistas.AddAsync(dentista);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Dentista dentista)
        {
            _context.Dentistas.Update(dentista);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var dentista = await _context.Dentistas.FindAsync(id);
            if (dentista != null)
            {
                _context.Dentistas.Remove(dentista);
                await _context.SaveChangesAsync();
            }
        }
    }
}
