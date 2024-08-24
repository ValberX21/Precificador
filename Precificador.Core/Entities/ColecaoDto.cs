using Dapper;
using System;

namespace Precificador.Core.Entities
{
    internal class ColecaoDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public DateTime DataLancamento { get; set; }
    }
}