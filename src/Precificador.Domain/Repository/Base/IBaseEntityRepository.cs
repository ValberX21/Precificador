using Precificador.Domain.Entities.Base;

namespace Precificador.Domain.Repository.Base
{
    public interface IBaseEntityRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllByNameAsync(string nome);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(Guid id);
    }
}