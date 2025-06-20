namespace Precificador.Domain.Filters
{
    public class NomeFilter : IFilter
    {
        public string? Nome { get; set; }

        public bool IsApplied()
        {
            return !string.IsNullOrEmpty(Nome);
        }
    }
}