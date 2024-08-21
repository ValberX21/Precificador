using System.ComponentModel.DataAnnotations;

namespace Precificador.Core.Entities
{
    internal class InsumoProdutoDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdProduto { get; set; }
        [Required]
        public int IdInsumo { get; set; }
        [Required]
        public decimal Quantidade { get; set; }
    }
}