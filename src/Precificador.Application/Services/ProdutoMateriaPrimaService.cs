using Precificador.Application.Services.Base;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository;

namespace Precificador.Application.Services
{
    public class ProdutoMateriaPrimaService(IProdutoMateriaPrimaRepository repository) : CrudServiceBase<Model.ProdutoMateriaPrima, Domain.Entities.ProdutoMateriaPrima, ProdutoMateriaPrimaFilter, IProdutoMateriaPrimaRepository>(repository), IProdutoMateriaPrimaService
    {
        protected override Domain.Entities.ProdutoMateriaPrima ConvertToEntity(Model.ProdutoMateriaPrima model)
        {
            return new Domain.Entities.ProdutoMateriaPrima
            {
                Id = model.Id,
                ProdutoId = model.ProdutoId,
                MateriaPrimaId = model.MateriaPrimaId,
                Quantidade = model.Quantidade
            };
        }

        protected override Model.ProdutoMateriaPrima ConvertToModel(Domain.Entities.ProdutoMateriaPrima entity)
        {
            return new Model.ProdutoMateriaPrima
            {
                Id = entity.Id,
                ProdutoId = entity.ProdutoId,
                MateriaPrimaId = entity.MateriaPrimaId,
                Quantidade = entity.Quantidade
            };
        }

        protected override void UpdateEntityFromModel(Domain.Entities.ProdutoMateriaPrima entity, Model.ProdutoMateriaPrima model)
        {
            entity.ProdutoId = model.ProdutoId;
            entity.MateriaPrimaId = model.MateriaPrimaId;
            entity.Quantidade = model.Quantidade;
        }

        protected override async Task<IEnumerable<Domain.Entities.ProdutoMateriaPrima>> GetEntitiesByFilterAsync(ProdutoMateriaPrimaFilter filter)
        {
            return await _repository.GetByFilterAsync(filter);
        }
    }
}