using codeclin.Domain.Entities;

namespace codeclin.Domain.Interfaces
{
    public interface IPagamentoRepository
    {
        Task<IEnumerable<Pagamento>> GetAllAsync();
        Task<Pagamento> GetByIdAsync(int id);
        Task AddAsync(Pagamento pagamento);
        Task UpdateAsync(Pagamento pagamento);
        Task DeleteAsync(int id);
    }
}
