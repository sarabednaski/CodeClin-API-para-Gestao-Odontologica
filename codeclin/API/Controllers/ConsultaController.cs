using codeclin.Application.Service;
using codeclin.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace codeclin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly ConsultaService _consultaService;

        public ConsultaController(ConsultaService consultaService)
        {
            _consultaService = consultaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _consultaService.GetAllConsultasAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var consulta = await _consultaService.GetConsultaByIdAsync(id);
            if (consulta == null) return NotFound();
            return Ok(consulta);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Consulta consulta)
        {
            await _consultaService.AddConsultaAsync(consulta);
            return CreatedAtAction(nameof(GetById), new { id = consulta.Id }, consulta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Consulta consulta)
        {
            if (id != consulta.Id) return BadRequest();
            await _consultaService.UpdateConsultaAsync(consulta);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _consultaService.DeleteConsultaAsync(id);
            return NoContent();
        }
    }
}
