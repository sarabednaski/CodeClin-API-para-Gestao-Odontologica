using codeclin.Application.Service;
using codeclin.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace codeclin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        private readonly PagamentoService _pagamentoService;

        public PagamentoController(PagamentoService pagamentoService)
        {
            _pagamentoService = pagamentoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _pagamentoService.GetAllPagamentosAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pagamento = await _pagamentoService.GetPagamentoByIdAsync(id);
            if (pagamento == null) return NotFound();
            return Ok(pagamento);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Pagamento pagamento)
        {
            await _pagamentoService.AddPagamentoAsync(pagamento);
            return CreatedAtAction(nameof(GetById), new { id = pagamento.Id }, pagamento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Pagamento pagamento)
        {
            if (id != pagamento.Id) return BadRequest();
            await _pagamentoService.UpdatePagamentoAsync(pagamento);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _pagamentoService.DeletePagamentoAsync(id);
            return NoContent();
        }
    }
}
