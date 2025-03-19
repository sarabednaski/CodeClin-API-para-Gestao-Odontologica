namespace codeclin.Application.DTOs
{
    public class ConsultaDTO
    {
        public int? Id { get; set; }
        public int PacienteId { get; set; }
        public int DentistaId { get; set; }
        public DateTime DataHora { get; set; }
        public string Observacoes { get; set; } = string.Empty;
    }
}
