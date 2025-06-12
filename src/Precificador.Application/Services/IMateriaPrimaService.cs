using Precificador.Application.Services.Base;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository;

namespace Precificador.Application.Services
{
    public interface IMateriaPrimaService : ICrudService<Model.MateriaPrima, Domain.Entities.MateriaPrima, NomeFilter, IMateriaPrimaRepository>
    {
    }
}