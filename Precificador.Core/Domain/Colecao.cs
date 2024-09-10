using System;
using System.Collections.Generic;

namespace Precificador.Core.Domain
{
    public class Colecao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataLancamento { get; set; }
        public int Ano { get { return DataLancamento.Year; } }

        public static List<Colecao> Listar(string filtroColecao, int filtroAnoLancamento)
        {
            var repository = new ColecaoRepository();
            return repository.Listar(filtroColecao, filtroAnoLancamento);
        }

        public static Colecao GetById(int id)
        {
            var repository = new ColecaoRepository();
            return repository.GetById(id);
        }
    }
}
