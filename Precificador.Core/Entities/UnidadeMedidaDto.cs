using Dapper;

namespace Precificador.Core.Entities
{
    internal class UnidadeMedidaDto : BaseEntity
    {
        [Required]
        public string Nome { get; set; }
    }
}