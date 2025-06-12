using Precificador.Application.Services.Base;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository;

namespace Precificador.Application.Services
{
    public class UnidadeMedidaService(IUnidadeMedidaRepository repository) : CrudServiceBase<Model.UnidadeMedida, Domain.Entities.UnidadeMedida, NomeFilter, IUnidadeMedidaRepository>(repository), IUnidadeMedidaService
    {
        protected override Domain.Entities.UnidadeMedida ConvertToEntity(Model.UnidadeMedida model)
        {
            return new Domain.Entities.UnidadeMedida
            {
                Id = model.Id,
                Nome = model.Nome,
                Abrebiacao = model.Abreviacao
            };
        }

        protected override Model.UnidadeMedida ConvertToModel(Domain.Entities.UnidadeMedida entity)
        {
            return new Model.UnidadeMedida
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Abreviacao = entity.Abrebiacao
            };
        }

        protected override void UpdateEntityFromModel(Domain.Entities.UnidadeMedida entity, Model.UnidadeMedida model)
        {
            entity.Nome = model.Nome;
            entity.Abrebiacao = model.Abreviacao;
        }

        protected override async Task<IEnumerable<Domain.Entities.UnidadeMedida>> GetEntitiesByFilterAsync(NomeFilter filter)
        {
            return await _repository.GetByFilterAsync(filter);
        }
    }
}