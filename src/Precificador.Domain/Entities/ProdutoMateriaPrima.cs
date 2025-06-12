using Precificador.Domain.Entities.Base;

namespace Precificador.Domain.Entities
{
    public class ProdutoMateriaPrima : CrudBase
    {
        public Guid ProdutoId { get; set; }
        public Produto? Produto { get; set; }
        public Guid MateriaPrimaId { get; set; }
        public MateriaPrima? MateriaPrima { get; set; }
        public decimal Quantidade { get; set; }
    }
}