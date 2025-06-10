using System.ComponentModel.DataAnnotations;

namespace Precificador.Domain.Entities.Base
{
    public abstract class CrudBase
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public bool Ativo { get; set; }
    }
}