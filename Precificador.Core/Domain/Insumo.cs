namespace Precificador.Core.Domain
{
    public class Insumo
    {
        public int Id { get; set; }
        public TipoInsumo TipoInsumo { get; set; }
        public string Nome { get; set; }
        public decimal PrecoPacote { get; set; }
        public decimal QuantidadePacote { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }
        public decimal PrecoUnidade { get; set; }
        public DateTime DataPreco { get; set; }
    }
}
