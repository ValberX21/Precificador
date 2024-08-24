using Precificador.Core.Entities;
using Precificador.Core.Interfaces;

namespace Precificador.Core.Repositories
{
    internal class ProdutoRepository : BaseRepository<ProdutoDto>, IProdutoRepository
    {
        public ProdutoRepository(string connectionString) : base(connectionString)
        {
            //
        }

        //internal List<Produto> Listar(int filtroColecao, string filtroProduto)
        //{
        //    var retorno = new List<Produto>();

        //    using (var connection = new SqlConnection(connectionString))
        //    {
        //        //TODO: Implementar Simple CRUD ... Operações
        //    }

        //    return retorno;
        //}
    }
}
