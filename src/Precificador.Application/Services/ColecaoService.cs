using System.Text.Json;
using Precificador.Application.Services.Base;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository;

namespace Precificador.Application.Services
{
    public class ColecaoService(IColecaoRepository repository) : CrudServiceBase<Model.Colecao, Domain.Entities.Colecao, ColecaoFilter, IColecaoRepository>(repository), IColecaoService
    {
        protected override Domain.Entities.Colecao ConvertToEntity(Model.Colecao model)
        {
            return new Domain.Entities.Colecao
            {
                Id = model.Id,
                Nome = model.Nome,
                Ano = model.Ano,
                DataLancamento = model.DataLancamento
            };
        }

        protected override Model.Colecao ConvertToModel(Domain.Entities.Colecao entity)
        {
            return new Model.Colecao
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Ano = entity.Ano,
                DataLancamento = entity.DataLancamento
            };
        }

        protected override void UpdateEntityFromModel(Domain.Entities.Colecao entity, Model.Colecao model)
        {
            entity.Nome = model.Nome;
            entity.Ano = model.Ano;
            entity.DataLancamento = model.DataLancamento;
        }

        public async Task<IEnumerable<Model.Colecao>> GetEntitiesByFilterAsync(string param)
        {
            if (string.IsNullOrWhiteSpace(param))
            {
                throw new ArgumentException("Parameter cannot be null or empty.", nameof(param));
            }

            var filter = JsonSerializer.Deserialize<ColecaoFilter>(param) ?? throw new ArgumentException("Deserialized filter cannot be null.", nameof(param));
            var entities = await _repository.GetByFilterAsync(filter);
            return entities.Select(ConvertToModel);
        }
    }
}