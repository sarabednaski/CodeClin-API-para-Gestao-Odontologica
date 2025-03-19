using codeclin.Domain.Entities;
using codeclin.Application.DTOs;
using AutoMapper;
using codeclin.Domain.Interfaces;


namespace codeclin.Application.Service
{
    public class PacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMapper _mapper;

        public PacienteService(IPacienteRepository pacienteRepository, IMapper mapper)
        {
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
        }

        public async Task<List<PacienteDTO>> ObterTodosAsync()
        {
            var pacientes = await _pacienteRepository.ObterTodosAsync();
            return _mapper.Map<List<PacienteDTO>>(pacientes);
        }

        public async Task<PacienteDTO> ObterPorIdAsync(int id)
        {
            var paciente = await _pacienteRepository.ObterPorIdAsync(id);
            return _mapper.Map<PacienteDTO>(paciente);
        }

        public async Task<PacienteDTO> CriarPacienteAsync(PacienteDTO pacienteDto)
        {
            var paciente = _mapper.Map<Paciente>(pacienteDto);
            await _pacienteRepository.AdicionarAsync(paciente);
            return _mapper.Map<PacienteDTO>(paciente);
        }

        public async Task AtualizarPacienteAsync(int id, PacienteDTO pacienteDto)
        {
            var paciente = await _pacienteRepository.ObterPorIdAsync(id);
            if (paciente == null) throw new Exception("Paciente não encontrado!");

            _mapper.Map(pacienteDto, paciente);
            await _pacienteRepository.AtualizarAsync(paciente);
        }

        public async Task DeletarPacienteAsync(int id)
        {
            await _pacienteRepository.RemoverAsync(id);
        }
    }
}
