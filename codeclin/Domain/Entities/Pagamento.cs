namespace codeclin.Domain.Entities
{
    public class Pagamento
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataPagamento { get; set; }
        public string MetodoPagamento { get; set; } = "Cartão";

        public int ConsultaId { get; set; }
        public Consulta Consulta { get; set; }
    }
}
