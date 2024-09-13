using Precificador.Core.Entities;
using System.Collections.Generic;
using System.Data;

namespace Precificador.Core.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        int? Add(TEntity entity);

        int Delete(int id);

        int Update(TEntity entity);

        TEntity Get(int id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetListPaged(int pageNumber, int rowPerPages, string conditions, string orderby);

        int Count(string conditions);

        TEntity ExecuteSingle(string query, object parameters = null);

        TEntity ExecuteSingle<TEntity>(string query, object parameters = null, CommandType commandType = CommandType.Text, int commandTimeOut = 60);

        TEntity ExecuteSingleOrDefault(string query, object parameters = null);

        IEnumerable<TEntity> Execute(string query, object parameters = null, CommandType commandType = CommandType.Text, int commandTimeOut = 60);
    }
}