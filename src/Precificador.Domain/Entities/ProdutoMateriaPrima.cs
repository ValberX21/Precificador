using System.ComponentModel.DataAnnotations;

namespace Precificador.Domain.Entities
{
    public class ProdutoMateriaPrima
    {
        [Key]
        public Guid Id { get; set; }
        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }
        public int MateriaPrimaId { get; set; }
        public MateriaPrima? MateriaPrima { get; set; }
        public decimal Quantidade { get; set; }
    }
}