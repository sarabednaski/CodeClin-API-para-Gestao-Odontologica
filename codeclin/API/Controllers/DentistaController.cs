using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using codeclin.Application.Service;
using codeclin.Domain.Entities;

namespace codeclin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DentistaController : ControllerBase
    {
        private readonly DentistaService _dentistaService;

        public DentistaController(DentistaService dentistaService)
        {
            _dentistaService = dentistaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDentistas()
        {
            var dentistas = await _dentistaService.GetAllDentistasAsync();
            return Ok(dentistas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDentistaById(int id)
        {
            var dentista = await _dentistaService.GetDentistaByIdAsync(id);
            if (dentista == null) return NotFound();
            return Ok(dentista);
        }

        [HttpPost]
        public async Task<IActionResult> AddDentista([FromBody] Dentista dentista)
        {
            await _dentistaService.AddDentistaAsync(dentista);
            return CreatedAtAction(nameof(GetDentistaById), new { id = dentista.Id }, dentista);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDentista(int id, [FromBody] Dentista dentista)
        {
            if (id != dentista.Id) return BadRequest();
            await _dentistaService.UpdateDentistaAsync(dentista);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDentista(int id)
        {
            await _dentistaService.DeleteDentistaAsync(id);
            return NoContent();
        }
    }
}
