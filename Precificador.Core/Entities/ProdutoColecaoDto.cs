using System.ComponentModel.DataAnnotations;

namespace Precificador.Core.Entities
{
    internal class ProdutoColecaoDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdColecao { get; set; }
        
        [Required]
        public int IdProduto { get; set; }
    }
}