namespace Precificador.Core.Domain
{
    public class ColecaoProduto
    {
        public int Id { get; set; }
        public Colecao Colecao { get; set; }
        public Produto Produto { get; set; }
    }
}
