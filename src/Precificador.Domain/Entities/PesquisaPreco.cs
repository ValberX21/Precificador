using System.ComponentModel.DataAnnotations;

namespace Precificador.Domain.Entities
{
    public class PesquisaPreco
    {
        [Key]
        public Guid Id { get; set; }
        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }
        public required string Local { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataPesquisa { get; set; }
    }
}