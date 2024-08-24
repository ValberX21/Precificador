using Dapper;

namespace Precificador.Core.Entities
{
    internal class TipoInsumoDto : BaseEntity
    {
        [Required]
        public string Nome { get; set; }
    }
}