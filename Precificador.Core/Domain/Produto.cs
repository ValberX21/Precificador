using Precificador.Core.Entities;
using Precificador.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Precificador.Core.Domain
{
    public class Produto
    {
        private static readonly IProdutoRepository _repository;

        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Custo { get; set; }
        public decimal Margem { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal PrecoPromocional { get; set; }
        public DateTime DataPreco { get; set; }

        public Produto(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public static async Task<List<Produto>> Listar(int filtroColecao, string filtroProduto)
        {
            var produtos = new List<ProdutoDto>();

            if ((filtroColecao == 0) && (string.IsNullOrWhiteSpace(filtroProduto)))
            {
                produtos = _repository.GetAll();
            }
            else
            {
                //TODO: Colocar filtroColecao, filtroProduto no conditions
                var conditions = string.Empty;
                produtos = _repository.GetListPaged(0, 1000, conditions, string.Empty);
            }

            return produtos.Map();
        }
    }
}