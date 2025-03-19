using codeclin.Domain.Entities;
using codeclin.Domain.Interfaces;

namespace codeclin.Application.Service
{
    public class PagamentoService
    {
        private readonly IPagamentoRepository _pagamentoRepository;

        public PagamentoService(IPagamentoRepository pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
        }

        public async Task<IEnumerable<Pagamento>> GetAllPagamentosAsync()
        {
            return await _pagamentoRepository.GetAllAsync();
        }

        public async Task<Pagamento> GetPagamentoByIdAsync(int id)
        {
            return await _pagamentoRepository.GetByIdAsync(id);
        }

        public async Task AddPagamentoAsync(Pagamento pagamento)
        {
            await _pagamentoRepository.AddAsync(pagamento);
        }

        public async Task UpdatePagamentoAsync(Pagamento pagamento)
        {
            await _pagamentoRepository.UpdateAsync(pagamento);
        }

        public async Task DeletePagamentoAsync(int id)
        {
            await _pagamentoRepository.DeleteAsync(id);
        }
    }
}
