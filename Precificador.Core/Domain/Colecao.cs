using System;

namespace Precificador.Core.Domain
{
    public class Colecao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataLancamento { get; set; }
        public int Ano { get { return DataLancamento.Year; } }
    }
}
