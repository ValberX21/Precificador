using Precificador.Application.Services.Base;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository;

namespace Precificador.Application.Services
{
    public interface IPesquisaPrecoService : ICrudService<Model.PesquisaPreco, Domain.Entities.PesquisaPreco, PesquisaPrecoFilter, IPesquisaPrecoRepository>
    {
    }
}