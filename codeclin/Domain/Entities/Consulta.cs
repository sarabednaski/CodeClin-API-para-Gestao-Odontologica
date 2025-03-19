namespace codeclin.Domain.Entities
{
    public class Consulta
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public string Observacoes { get; set; } = string.Empty;
        
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public int DentistaId { get; set; }
        public Dentista Dentista { get; set; }
    }
}
