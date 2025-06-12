using Precificador.Application.Services.Base;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository;

namespace Precificador.Application.Services
{
    public interface IProdutoService : ICrudService<Model.Produto, Domain.Entities.Produto, NomeFilter, IProdutoRepository>
    {
    }
}