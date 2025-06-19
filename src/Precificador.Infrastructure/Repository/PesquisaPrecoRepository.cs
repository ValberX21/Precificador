using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Precificador.Domain.Entities;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository;
using Precificador.Infrastructure.Data;
using Precificador.Infrastructure.Repository.Base;

namespace Precificador.Infrastructure.Repository
{
    public class PesquisaPrecoRepository(AppDbContext context, ILogger<PesquisaPreco> logger) : CrudRepositoryBase<PesquisaPreco, PesquisaPrecoFilter>(context, logger), IPesquisaPrecoRepository
    {
        public override async Task<IEnumerable<PesquisaPreco>> GetByFilterAsync(PesquisaPrecoFilter filter)
        {
            try
            {
                var query = _context.PesquisasPrecos.AsQueryable().Where(c => c.Ativo);

                if (filter != null)
                {
                    if (filter.ProdutoId.HasValue)
                    {
                        query = query.Where(c => c.ProdutoId == filter.ProdutoId.Value);
                    }

                    if (!string.IsNullOrEmpty(filter.ProdutoNome))
                    {
                        query = query.Where(c => c.Produto != null && c.Produto.Nome.Contains(filter.ProdutoNome));
                    }

                    if (!string.IsNullOrEmpty(filter.Local))
                    {
                        query = query.Where(c => c.Local.Contains(filter.Local));
                    }

                    if (filter.DataPesquisa.HasValue)
                    {
                        query = query.Where(c => c.DataPesquisa == filter.DataPesquisa.Value);
                    }
                }

                return await query.ToListAsync().ConfigureAwait(false);
            }
            catch (DbUpdateException ex)
            {
                _logErrorFetchingByFilter(_logger, typeof(PesquisaPreco).Name, ex);
                return [];
            }
            catch (InvalidOperationException ex)
            {
                _logErrorFetchingByFilter(_logger, typeof(PesquisaPreco).Name, ex);
                return [];
            }
        }
    }
}