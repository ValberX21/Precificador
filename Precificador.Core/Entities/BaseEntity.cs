using Dapper;

namespace Precificador.Core.Entities
{
    internal class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}
