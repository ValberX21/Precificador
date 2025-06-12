using Precificador.Application.Services.Base;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository;

namespace Precificador.Application.Services
{
    public interface IUnidadeMedidaService : ICrudService<Model.UnidadeMedida, Domain.Entities.UnidadeMedida, NomeFilter, IUnidadeMedidaRepository>
    {
    }
}