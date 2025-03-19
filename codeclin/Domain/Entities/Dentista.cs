namespace codeclin.Domain.Entities
{
    public class Dentista
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CRO { get; set; } = string.Empty;
        public string Especialidade { get; set; } = string.Empty;
        public List<Consulta> Consultas { get; set; } = new List<Consulta>();
    }
}
