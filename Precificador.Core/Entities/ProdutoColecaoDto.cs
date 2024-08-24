using Dapper;

namespace Precificador.Core.Entities
{
    internal class ProdutoColecaoDto : BaseEntity
    {
        [Required]
        public int IdColecao { get; set; }

        [Required]
        public int IdProduto { get; set; }
    }
}