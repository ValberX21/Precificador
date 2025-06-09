namespace Precificador.Application.Services.Base
{
    public interface IBaseModelService<T> : IBaseService<T>
    {
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<T>> GetAllByNameAsync(string nome);
    }
}