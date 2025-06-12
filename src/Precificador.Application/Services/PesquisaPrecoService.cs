using Precificador.Application.Services.Base;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository;

namespace Precificador.Application.Services
{
    public class PesquisaPrecoService(IPesquisaPrecoRepository repository) : CrudServiceBase<Model.PesquisaPreco, Domain.Entities.PesquisaPreco, NomeFilter, IPesquisaPrecoRepository>(repository), IPesquisaPrecoService
    {
       
    }
}