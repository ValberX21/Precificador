using Dapper;

namespace Precificador.Core.Entities
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}