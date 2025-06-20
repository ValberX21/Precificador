namespace Precificador.Domain.Filters
{
    public class PesquisaPrecoFilter : IFilter
    {
        public Guid? ProdutoId { get; set; }
        public string? ProdutoNome { get; set; }
        public string? Local { get; set; }
        public DateTime? DataPesquisa { get; set; }

        public bool IsApplied()
        {
            return ProdutoId.HasValue || !string.IsNullOrEmpty(ProdutoNome) || !string.IsNullOrEmpty(Local) || DataPesquisa.HasValue;
        }
    }
}