﻿namespace Precificador.Domain.Filters
{
    public class ProdutoMateriaPrimaFilter : IFilter
    {
        public Guid? ProdutoId { get; set; }
        public string? ProdutoNome { get; set; }
        public Guid? MateriaPrimaId { get; set; }
        public string? MateriaPrimaNome { get; set; }

        public bool IsApplied()
        {
            return ProdutoId.HasValue || !string.IsNullOrEmpty(ProdutoNome) || MateriaPrimaId.HasValue || !string.IsNullOrEmpty(MateriaPrimaNome);
        }
    }
}