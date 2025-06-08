using Precificador.Application.Model;
using Precificador.Application.Model.Extensions;
using Precificador.Domain.Repository;

namespace Precificador.Application.Services
{
    public class ColecaoService(IColecaoRepository repository) : IColecaoService
    {
        private readonly IColecaoRepository _repository = repository;

        public async Task<bool> AddAsync(Colecao model)
        {
            return await _repository.AddAsync(model.ConvertToEntity());
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
            {
                return false;
            }

            entity.Ativo = false;
            return await _repository.UpdateAsync(entity);
        }

        public async Task<IList<Colecao>> GetAllAsync()
        {
            return (await _repository.GetAllAsync())?.ConvertToModel();
        }

        public async Task<IEnumerable<Colecao>> GetAllByNameAsync(string nome)
        {
            return (await _repository.GetAllByNameAsync(nome)).ConvertToModel();
        }

        public async Task<Colecao> GetByIdAsync(Guid id)
        {
            return (await _repository.GetByIdAsync(id))?.ConvertToModel();
        }

        public async Task<bool> UpdateAsync(Colecao value)
        {
            var entity = await _repository.GetByIdAsync(value.Id);

            if (entity == null)
            {
                return false;
            }

            entity.Nome = value.Nome;
            return await _repository.UpdateAsync(entity);
        }
    }
}
