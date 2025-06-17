using System.ComponentModel.DataAnnotations;
using Precificador.Application.Model;

namespace Precificador.Tests.Application.Model
{
    public class PesquisaPrecoTests
    {
        [Fact]
        public void DataPesquisa_NaoDeveSerAnteriorAUmMes()
        {
            var pesquisa = new PesquisaPreco
            {
                ProdutoId = Guid.NewGuid(),
                Local = "Loja 1",
                Valor = 10.0m,
                DataPesquisa = DateTime.Now.AddMonths(-2)
            };
            var results = new List<ValidationResult>();
            var context = new ValidationContext(pesquisa);

            bool isValid = Validator.TryValidateObject(pesquisa, context, results, true);

            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage == "Data da Pesquisa não deve ser anterior a 1 mês");
        }

        [Fact]
        public void DataPesquisa_NaoDeveSerNoFuturo()
        {
            var pesquisa = new PesquisaPreco
            {
                ProdutoId = Guid.NewGuid(),
                Local = "Loja 1",
                Valor = 10.0m,
                DataPesquisa = DateTime.Now.AddDays(1)
            };
            var results = new List<ValidationResult>();
            var context = new ValidationContext(pesquisa);

            bool isValid = Validator.TryValidateObject(pesquisa, context, results, true);

            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage == "Data da Pesquisa não deve ser anterior a 1 mês");
        }
    }
}