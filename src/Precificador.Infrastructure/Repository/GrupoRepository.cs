using Microsoft.Extensions.Logging;
using Precificador.Domain.Entities;
using Precificador.Domain.Repository;
using Precificador.Infrastructure.Data;
using Precificador.Infrastructure.Repository.Base;

namespace Precificador.Infrastructure.Repository
{
    public class GrupoRepository(AppDbContext context, ILogger<Grupo> logger) : BaseEntityRepository<Grupo>(context, logger), IGrupoRepository
    {
    }
}
