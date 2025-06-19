using Precificador.Domain.Entities.Base;

namespace Precificador.Domain.Entities
{
    public class UnidadeMedida : CrudBase
    {
        public required string Nome { get; set; }
        public required string Abrebiacao { get; set; }
    }
}
