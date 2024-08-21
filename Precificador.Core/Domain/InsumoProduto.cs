namespace Precificador.Core.Domain
{
    public class InsumoProduto
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public Insumo Insumo { get; set; }
        public decimal Quantidade { get; set; }
    }
}