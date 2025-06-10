using Precificador.Domain.Entities.Base;

namespace Precificador.Domain.Entities
{
    public class Grupo : CrudBase
    {
        public required string Nome { get; set; }
        public ICollection<MateriaPrima>? MateriasPrimas { get; set; }
    }
}