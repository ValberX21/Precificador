namespace Precificador.Domain.Entities
{
    public class Grupo : BaseEntity
    {
        public ICollection<MateriaPrima>? MateriasPrimas { get; set; }
    }
}