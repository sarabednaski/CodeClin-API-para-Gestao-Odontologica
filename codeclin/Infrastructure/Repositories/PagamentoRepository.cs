using codeclin.DataContext;
using codeclin.Domain.Entities;
using codeclin.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace codeclin.Infrastructure.Repositories
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly ApplicationDbContext _context;

        public PagamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pagamento>> GetAllAsync() => await _context.Pagamentos.ToListAsync();
        public async Task<Pagamento> GetByIdAsync(int id) => await _context.Pagamentos.FindAsync(id);

        public async Task AddAsync(Pagamento pagamento)
        {
            await _context.Pagamentos.AddAsync(pagamento);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pagamento pagamento)
        {
            _context.Pagamentos.Update(pagamento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pagamento = await _context.Pagamentos.FindAsync(id);
            if (pagamento != null)
            {
                _context.Pagamentos.Remove(pagamento);
                await _context.SaveChangesAsync();
            }
        }
    }
}
