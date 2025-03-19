using codeclin.Domain.Entities;

namespace codeclin.Domain.Interfaces
{
    public interface IDentistaRepository
    {
        Task<IEnumerable<Dentista>> GetAllAsync();
        Task<Dentista> GetByIdAsync(int id);
        Task AddAsync(Dentista dentista);
        Task UpdateAsync(Dentista dentista);
        Task DeleteAsync(int id);
    }
}
