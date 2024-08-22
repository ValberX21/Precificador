using System.ComponentModel.DataAnnotations;

namespace Precificador.Core.Entities
{
    internal class TipoInsumoDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
    }
}