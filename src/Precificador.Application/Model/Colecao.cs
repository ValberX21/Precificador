using System.ComponentModel.DataAnnotations;

namespace Precificador.Application.Model
{
    public class Colecao
    {
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Necessário Informar o Nome da Coleção")]
        [MaxLength(100, ErrorMessage = "Nome da Coleção deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }
    }
}