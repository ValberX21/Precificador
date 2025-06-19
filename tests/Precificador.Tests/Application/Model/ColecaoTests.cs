using System.ComponentModel.DataAnnotations;
using Precificador.Application.Model;

namespace Precificador.Tests.Application.Model
{
    public class ColecaoTests
    {
        [Theory]
        [InlineData(2015)]
        [InlineData(1900)]
        [InlineData(999)]
        public void ValidateAno_DeveRetornarErro_SeAnoForMenorQue2016(int anoInvalido)
        {
            var result = Colecao.ValidateAno(anoInvalido);
            Assert.NotNull(result);
            Assert.Equal("Ano de Lançamento deve estar entre 2016 e o ano atual", result.ErrorMessage);
        }

        [Fact]
        public void ValidateAno_DeveRetornarErro_SeAnoForMaiorQueAnoAtual()
        {
            int anoInvalido = DateTime.Now.Year + 1;
            var result = Colecao.ValidateAno(anoInvalido);
            Assert.NotNull(result);
            Assert.Equal("Ano de Lançamento deve estar entre 2016 e o ano atual", result.ErrorMessage);
        }

        [Theory]
        [InlineData(2016)]
        [InlineData(2020)]
        [InlineData(2024)]
        public void ValidateAno_DeveRetornarSucesso_SeAnoForValido(int anoValido)
        {
            var result = Colecao.ValidateAno(anoValido);
            Assert.Equal(ValidationResult.Success, result);
        }

        [Fact]
        public void ValidateDataLancamento_DeveRetornarErro_SeDataForAnteriorACriacaoDaLoja()
        {
            var dataInvalida = DateTime.Parse("2015-12-31");
            var result = Colecao.ValidateDataLancamento(dataInvalida);
            Assert.NotNull(result);
            Assert.Equal("Data de Lançamento deve ser posterior à criação da loja", result.ErrorMessage);
        }

        [Fact]
        public void ValidateDataLancamento_DeveRetornarSucesso_SeDataForNula()
        {
            var result = Colecao.ValidateDataLancamento(null);
            Assert.Equal(ValidationResult.Success, result);
        }

        [Fact]
        public void ValidateDataLancamento_DeveRetornarSucesso_SeDataForValida()
        {
            var dataValida = DateTime.Parse("2016-01-12");
            var result = Colecao.ValidateDataLancamento(dataValida);
            Assert.Equal(ValidationResult.Success, result);
        }
    }
}