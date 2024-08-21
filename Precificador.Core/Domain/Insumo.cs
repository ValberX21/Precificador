namespace Precificador.Core.Domain
{
    public class Insumo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal PrecoPacote { get; set; }
        public decimal QuantidadePacote { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}
