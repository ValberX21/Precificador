namespace Precificador.Domain.Entities
{
    public class Produto : BaseEntity
    {
        public int ColecaoId { get; set; }
        public Colecao? Colecao { get; set; }
        public decimal Margem { get; set; }
        public DateTime DataCalculoPreco { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoFinal { get { return PrecoCusto * (1 + Margem); } }
        public decimal PrecoCustoX3 { get { return PrecoCusto * 3; } }
        public decimal PrecoCustoX35 { get { return PrecoCusto * 3.5m; } }
        public decimal PrecoCustoX4 { get { return PrecoCusto * 4; } }

        public ICollection<ProdutoMateriaPrima>? MateriasPrimas { get; set; }
        public ICollection<PesquisaPreco>? Pesquisas { get; set; }
    }
}