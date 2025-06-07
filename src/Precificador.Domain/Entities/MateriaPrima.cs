namespace Precificador.Domain.Entities
{
    public class MateriaPrima : BaseEntity
    {
        public required string Unidade { get; set; }
        public decimal QtdPacote { get; set; }
        public decimal VlrPacote { get; set; }
        public DateTime DataPreco { get; set; }
        public decimal VlrUnitario { get { return VlrPacote / QtdPacote; } }

        public int GrupoId { get; set; }
        public Grupo? Grupo { get; set; }
        public ICollection<ProdutoMateriaPrima>? Produtos { get; set; }
    }
}