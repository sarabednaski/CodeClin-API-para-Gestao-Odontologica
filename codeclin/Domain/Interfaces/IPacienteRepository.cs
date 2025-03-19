using codeclin.Domain.Entities;

namespace codeclin.Domain.Interfaces;

    public interface IPacienteRepository
    {
        Task<List<Paciente>> ObterTodosAsync();
        Task<Paciente> ObterPorIdAsync(int id);
        Task AdicionarAsync(Paciente paciente);
        Task AtualizarAsync(Paciente paciente);
        Task RemoverAsync(int id);
    }

