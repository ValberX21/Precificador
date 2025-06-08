using System.ComponentModel.DataAnnotations;

namespace Precificador.Domain.Entities
{
    public class ProdutoMateriaPrima
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ProdutoId { get; set; }
        public Produto? Produto { get; set; }
        public Guid MateriaPrimaId { get; set; }
        public MateriaPrima? MateriaPrima { get; set; }
        public decimal Quantidade { get; set; }
    }
}