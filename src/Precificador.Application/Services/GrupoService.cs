using Precificador.Application.Model;
using Precificador.Application.Model.Extensions;
using Precificador.Domain.Repository;

namespace Precificador.Application.Services
{
    public class GrupoService(IGrupoRepository repository) : IGrupoService
    {
        private readonly IGrupoRepository _repository = repository;

        public async Task<bool> AddAsync(Grupo model)
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

        public async Task<IList<Grupo>> GetAllAsync()
        {
            return (await _repository.GetAllAsync())?.ConvertToModel();
        }

        public async Task<IEnumerable<Grupo>> GetAllByNameAsync(string nome)
        {
            return (await _repository.GetAllByNameAsync(nome)).ConvertToModel();
        }

        public async Task<Grupo> GetByIdAsync(Guid id)
        {
            return (await _repository.GetByIdAsync(id))?.ConvertToModel();
        }

        public async Task<bool> UpdateAsync(Grupo value)
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
