using Dapper;
using System;

namespace Precificador.Core.Entities
{
    public class ColecaoDto : BaseEntity
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public DateTime DataLancamento { get; set; }
    }
}