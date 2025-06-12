using Precificador.Application.Services.Base;
using Precificador.Domain.Entities;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository;

namespace Precificador.Application.Services
{
    public class ColecaoService(IColecaoRepository repository) : CrudServiceBase<Model.Colecao, Domain.Entities.Colecao, NomeFilter, IColecaoRepository>(repository), IColecaoService
    {
        protected override Domain.Entities.Colecao ConvertToEntity(Model.Colecao model)
        {
            return new Domain.Entities.Colecao
            {
                Nome = model.Nome,
                Ano = model.Ano,
                DataLancamento = model.DataLancamento
            };
        }

        protected override Model.Colecao ConvertToModel(Domain.Entities.Colecao entity)
        {
            return new Model.Colecao
            {
                Nome = entity.Nome,
                Ano = entity.Ano,
                DataLancamento = entity.DataLancamento
            };
        }

        protected override Task<IEnumerable<Colecao>> GetEntitiesByFilterAsync(NomeFilter filter)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateEntityFromModel(Domain.Entities.Colecao entity, Model.Colecao model)
        {
            entity.Nome = model.Nome;
            entity.Ano = model.Ano;
            entity.DataLancamento = model.DataLancamento;
        }
    }
}