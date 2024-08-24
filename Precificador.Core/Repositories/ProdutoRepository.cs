using Precificador.Core.Domain;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Precificador.Core.Repositories
{
    internal class ProdutoRepository : RepositoryBase
    {
        internal List<Produto> Listar(int filtroColecao, string filtroProduto)
        {
            var retorno = new List<Produto>();

            using (var connection = new SqlConnection(connectionString))
            {
                //TODO: Implementar Simple CRUD ... Operações
            }

            return retorno;
        }
    }
}
