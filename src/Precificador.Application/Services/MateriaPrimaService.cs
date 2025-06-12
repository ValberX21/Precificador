using Precificador.Application.Services.Base;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository;

namespace Precificador.Application.Services
{
    public class MateriaPrimaService(IMateriaPrimaRepository repository) : CrudServiceBase<Model.MateriaPrima, Domain.Entities.MateriaPrima, NomeFilter, IMateriaPrimaRepository>(repository), IMateriaPrimaService
    {
        protected override Domain.Entities.MateriaPrima ConvertToEntity(Model.MateriaPrima model)
        {
            return new Domain.Entities.MateriaPrima
            {
                Id = model.Id,
                Nome = model.Nome,
                QtdPacote = model.QtdPacote,
                VlrPacote = model.VlrPacote,
                DataPreco = model.DataPreco,
                GrupoId = model.GrupoId,
                UnidadeMedidaId = model.UnidadeMedidaId
            };
        }

        protected override Model.MateriaPrima ConvertToModel(Domain.Entities.MateriaPrima entity)
        {
            return new Model.MateriaPrima
            {
                Id = entity.Id,
                Nome = entity.Nome,
                QtdPacote = entity.QtdPacote,
                VlrPacote = entity.VlrPacote,
                DataPreco = entity.DataPreco,
                VlrUnitario = entity.VlrUnitario,
                GrupoId = entity.GrupoId,
                UnidadeMedidaId = entity.UnidadeMedidaId
            };
        }

        protected override void UpdateEntityFromModel(Domain.Entities.MateriaPrima entity, Model.MateriaPrima model)
        {
            entity.Nome = model.Nome;
            entity.QtdPacote = model.QtdPacote;
            entity.VlrPacote = model.VlrPacote;
            entity.DataPreco = model.DataPreco;
            entity.GrupoId = model.GrupoId;
            entity.UnidadeMedidaId = model.UnidadeMedidaId;
        }

        protected override async Task<IEnumerable<Domain.Entities.MateriaPrima>> GetEntitiesByFilterAsync(NomeFilter filter)
        {
            return await _repository.GetByFilterAsync(filter);
        }
    }
}