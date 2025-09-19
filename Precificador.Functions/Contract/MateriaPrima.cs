namespace Precificador.Functions.Contract
{
    public class MateriaPrima
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public decimal QtdPacote { get; set; }
        public decimal VlrPacote { get; set; }

        public DateTime DataPreco { get; set; }
        public Guid GrupoId { get; set; }
        public Guid UnidadeMedidaId { get; set; }
        public DateTime DataCriacao { get; set; }
       
        public DateTime DataAlteracao { get; set; }
        public decimal VlrUnitario { get { return VlrPacote / QtdPacote; } }

       
    }
}
