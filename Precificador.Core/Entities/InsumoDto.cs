using Dapper;
using System;

namespace Precificador.Core.Entities
{
    internal class InsumoDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdTipoInsumo { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public decimal PrecoPacote { get; set; }
        [Required]
        public decimal QuantidadePacote { get; set; }
        [Required]
        public int IdUnidadeMedida { get; set; }
        [Required]
        public decimal PrecoUnidade { get; set; }
        [Required]
        public DateTime DataPreco { get; set; }
    }
}