using codeclin.Application.Service;
using Microsoft.AspNetCore.Mvc;
using codeclin.Application.DTOs;

namespace codeclin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly PacienteService _pacienteService;

        public PacienteController(PacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var pacientes = await _pacienteService.ObterTodosAsync();
            return Ok(pacientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var paciente = await _pacienteService.ObterPorIdAsync(id);
            if (paciente == null) return NotFound("Paciente não encontrado");
            return Ok(paciente);
        }

        [HttpPost]
        public async Task<IActionResult> CriarPaciente([FromBody] PacienteDTO pacienteDto)
        {
            var pacienteCriado = await _pacienteService.CriarPacienteAsync(pacienteDto);
            return CreatedAtAction(nameof(ObterPorId), new { id = pacienteCriado.Id }, pacienteCriado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarPaciente(int id, [FromBody] PacienteDTO pacienteDto)
        {
            await _pacienteService.AtualizarPacienteAsync(id, pacienteDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarPaciente(int id)
        {
            await _pacienteService.DeletarPacienteAsync(id);
            return NoContent();
        }
    }
}
