using Precificador.Domain.Entities;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository.Base;

namespace Precificador.Domain.Repository
{
    public interface IPesquisaPrecoRepository : ICrudRepository<PesquisaPreco, PesquisaPrecoFilter>
    {
    }
}