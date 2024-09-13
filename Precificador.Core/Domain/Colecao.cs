using Precificador.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace Precificador.Core.Domain
{
    public class Colecao
    {
        private readonly IColecaoRepository _repository;

        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataLancamento { get; set; }
        public int Ano { get { return DataLancamento.Year; } }

        public Colecao(IColecaoRepository repository)
        {
            _repository = repository;
        }

        public List<Colecao> Listar(string filtroColecao, int filtroAnoLancamento)
        {
            return _repository.Listar(filtroColecao, filtroAnoLancamento);
        }

        public Colecao Consultar(int id)
        {
            //TODO: Map
            return _repository.Get(id);
        }

        public void Excluir(int idColecao)
        {
            throw new NotImplementedException();
        }

        public void Salvar(Colecao colecao)
        {
            throw new NotImplementedException();
        }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
