using Microsoft.Extensions.Logging;
using Precificador.Domain.Entities;
using Precificador.Domain.Repository;
using Precificador.Infrastructure.Data;
using Precificador.Infrastructure.Repository.Base;

namespace Precificador.Infrastructure.Repository
{
    public class MateriaPrimaRepository(AppDbContext context, ILogger<MateriaPrima> logger) : BaseEntityRepository<MateriaPrima>(context, logger), IMateriaPrimaRepository
    {
    }
}
