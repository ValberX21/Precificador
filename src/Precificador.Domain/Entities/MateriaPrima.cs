using Precificador.Domain.Entities.Base;

namespace Precificador.Domain.Entities
{
    public class MateriaPrima : CrudBase
    {
        public required string Nome { get; set; }
        public decimal QtdPacote { get; set; }
        public decimal VlrPacote { get; set; }
        public DateTime DataPreco { get; set; }
        public decimal VlrUnitario { get { return VlrPacote / QtdPacote; } }

        public int GrupoId { get; set; }
        public Grupo? Grupo { get; set; }
        public int UnidadeMedidaId { get; set; }
        public UnidadeMedida? UnidadeMedida { get; set; }

        public ICollection<ProdutoMateriaPrima>? Produtos { get; set; }
    }
}