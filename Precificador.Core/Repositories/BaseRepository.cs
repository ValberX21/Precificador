using Dapper;
using Precificador.Core.Entities;
using Precificador.Core.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Precificador.Core.Repositories
{
    internal abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private const string connectionString = "Server=DESKTOP-49SJVTL;Database=Precificador;Integrated Security=SSPI;Persist Security Info=False;";

        protected string ConnectionString { get; set; }

        protected BaseRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public int? Add(TEntity entity)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var result = connection.Insert(entity);
                connection.Close();
                return result;
            }
        }

        public int Delete(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var entity = connection.Get<TEntity>(id);
                var result = connection.Delete(entity);
                connection.Close();
                return result;
            }
        }

        public int Update(TEntity entity)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var result = connection.Update(entity);
                connection.Close();
                return result;
            }
        }

        public TEntity Get(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var result = connection.Get<TEntity>(id);
                connection.Close();
                return result;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var result = connection.GetList<TEntity>();
                connection.Close();
                return result;
            }
        }

        public IEnumerable<TEntity> GetListPaged(int pageNumber, int rowPerPages, string conditions, string orderby)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var result = connection.GetListPaged<TEntity>(pageNumber, rowPerPages, conditions, orderby);
                connection.Close();
                return result;
            }
        }

        public int Count(string conditions)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var result = connection.RecordCount<int>(conditions);
                connection.Close();
                return result;
            }
        }

        public TEntity ExecuteSingle(string query, object parameters = null)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var result = connection.QuerySingle<TEntity>(query, parameters, commandType: CommandType.Text);
                connection.Close();
                return result;
            }
        }

        public TEntity ExecuteSingle<TEntity>(string query, object parameters = null, CommandType commandType = CommandType.Text, int commandTimeOut = 60)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var result = connection.QuerySingle<TEntity>(query, parameters, commandType: commandType, commandTimeout: commandTimeOut);
                connection.Close();
                return result;
            }
        }

        public TEntity ExecuteSingleOrDefault(string query, object parameters = null)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var result = connection.QuerySingleOrDefault<TEntity>(query, parameters, commandType: CommandType.Text);
                connection.Close();
                return result;
            }
        }

        public IEnumerable<TEntity> Execute(string query, object parameters = null, CommandType commandType = CommandType.Text, int commandTimeOut = 60)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var result = connection.Query<TEntity>(query, parameters, commandType: commandType, commandTimeout: commandTimeOut);
                connection.Close();
                return result;
            }
        }
    }
}