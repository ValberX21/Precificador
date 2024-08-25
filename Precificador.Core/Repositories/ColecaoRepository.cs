using Precificador.Core.Entities;
using Precificador.Core.Interfaces;

namespace Precificador.Core.Repositories
{
    internal class ColecaoRepository : BaseRepository<ColecaoDto>, IColecaoRepository
    {
        internal ColecaoRepository(string connectionString) : base(connectionString)
        {
            //
        }
    }
}