using Precificador.Application.Model;
using System.ComponentModel.DataAnnotations;

namespace Precificador.Tests.Model
{
    public class ColecaoTests
    {
        [Fact]
        public void ValidateAno_ShouldReturnSuccess_WhenValid()
        {
            var result = Colecao.ValidateAno(DateTime.Now.Year, new ValidationContext(new Colecao()));
            Assert.Equal(ValidationResult.Success, result);
        }

        [Fact]
        public void ValidateAno_ShouldReturnError_WhenTooLow()
        {
            var result = Colecao.ValidateAno(2015, new ValidationContext(new Colecao()));
            Assert.NotEqual(ValidationResult.Success, result);
            Assert.Equal("Ano de Lançamento deve estar entre 2016 e o ano atual", result.ErrorMessage);
        }

        [Fact]
        public void ValidateAno_ShouldReturnError_WhenTooHigh()
        {
            var result = Colecao.ValidateAno(DateTime.Now.Year + 1, new ValidationContext(new Colecao()));
            Assert.NotEqual(ValidationResult.Success, result);
            Assert.Equal("Ano de Lançamento deve estar entre 2016 e o ano atual", result.ErrorMessage);
        }

        [Fact]
        public void ValidateDataLancamento_ShouldReturnSuccess_WhenNull()
        {
            var result = Colecao.ValidateDataLancamento(null, new ValidationContext(new Colecao()));
            Assert.Equal(ValidationResult.Success, result);
        }

        [Fact]
        public void ValidateDataLancamento_ShouldReturnSuccess_WhenAfterMinDate()
        {
            var validDate = DateTime.Parse("2016-01-13");
            var result = Colecao.ValidateDataLancamento(validDate, new ValidationContext(new Colecao()));
            Assert.Equal(ValidationResult.Success, result);
        }

        [Fact]
        public void ValidateDataLancamento_ShouldReturnError_WhenBeforeMinDate()
        {
            var invalidDate = DateTime.Parse("2016-01-01");
            var result = Colecao.ValidateDataLancamento(invalidDate, new ValidationContext(new Colecao()));
            Assert.NotEqual(ValidationResult.Success, result);
            Assert.Equal("Data de Lançamento deve ser posterior à criação da loja", result.ErrorMessage);
        }
    }
}