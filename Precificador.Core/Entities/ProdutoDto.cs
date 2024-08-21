using System.ComponentModel.DataAnnotations;

namespace Precificador.Core.Entities
{
    internal class ProdutoDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public decimal Custo { get; set; }
        [Required]
        public decimal Margem { get; set; }
        [Required]
        public decimal PrecoVenda { get; set; }
        public decimal PrecoPromocional { get; set; }
    }
}