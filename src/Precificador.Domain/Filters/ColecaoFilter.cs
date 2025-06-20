namespace Precificador.Domain.Filters
{
    public class ColecaoFilter : IFilter
    {
        public string? Nome { get; set; }
        public int? Ano { get; set; }

        public bool IsApplied()
        {
            return !string.IsNullOrEmpty(Nome) || Ano.HasValue;
        }
    }
}