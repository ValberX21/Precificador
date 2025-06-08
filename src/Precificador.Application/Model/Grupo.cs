using System.ComponentModel.DataAnnotations;

namespace Precificador.Application.Model
{
    public class Grupo
    {
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Necessário Informar o Nome do Grupo")]
        [MaxLength(100, ErrorMessage = "Nome do Grupo deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }
    }
}
