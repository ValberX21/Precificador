using Precificador.Domain.Entities.Base;

namespace Precificador.Domain.Entities
{
    public class PesquisaPreco : CrudBase
    {
        public Guid ProdutoId { get; set; }
        public Produto? Produto { get; set; }
        public required string Local { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataPesquisa { get; set; }
    }
}