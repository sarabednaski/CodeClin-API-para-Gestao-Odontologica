using codeclin.Domain.Entities;
using codeclin.Domain.Interfaces;

namespace codeclin.Application.Service
{
    public class ConsultaService
    {
        private readonly IConsultaRepository _consultaRepository;

        public ConsultaService(IConsultaRepository consultaRepository)
        {
            _consultaRepository = consultaRepository;
        }

        public async Task<IEnumerable<Consulta>> GetAllConsultasAsync()
        {
            return await _consultaRepository.GetAllAsync();
        }

        public async Task<Consulta> GetConsultaByIdAsync(int id)
        {
            return await _consultaRepository.GetByIdAsync(id);
        }

        public async Task AddConsultaAsync(Consulta consulta)
        {
            await _consultaRepository.AddAsync(consulta);
        }

        public async Task UpdateConsultaAsync(Consulta consulta)
        {
            await _consultaRepository.UpdateAsync(consulta);
        }

        public async Task DeleteConsultaAsync(int id)
        {
            await _consultaRepository.DeleteAsync(id);
        }
    }
}
