using Dapper;
using System;

namespace Precificador.Core.Entities
{
    internal class ColecaoDto : BaseEntity
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public DateTime DataLancamento { get; set; }
    }
}