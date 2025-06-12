using Precificador.Application.Services.Base;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository;

namespace Precificador.Application.Services
{
    public interface IGrupoService : ICrudService<Model.Grupo, Domain.Entities.Grupo, NomeFilter, IGrupoRepository>
    {
    }
}