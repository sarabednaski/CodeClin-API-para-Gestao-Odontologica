namespace codeclin.Application.DTOs
{
    public class PagamentoDTO
    {
        public int? Id { get; set; }
        public int PacienteId { get; set; }
        public decimal Valor { get; set; }
        public string MetodoPagamento { get; set; } = string.Empty;
        public DateTime DataPagamento { get; set; }
    }
}
