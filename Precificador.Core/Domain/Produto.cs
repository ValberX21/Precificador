using Precificador.Core.Repositories;

namespace Precificador.Core.Domain
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Custo { get; set; }
        public decimal Margem { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal PrecoPromocional { get; set; }
        public DateTime DataPreco { get; set; }

        public List<Produto> Listar()
        {
            var repository = new ProdutoRepository();
            return repository.Listar();
        }
    }
}