using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Precificador.Application.Model;
using Precificador.Application.Services;
using Precificador.Domain.Filters;
using Precificador.WebApi.Controllers;

namespace Precificador.Tests.WebApi.Controllers
{
    public class ColecaoControllerTests
    {
        private readonly Mock<IColecaoService> _serviceMock;
        private readonly Mock<ILogger<ColecaoController>> _loggerMock;
        private readonly ColecaoController _controller;

        public ColecaoControllerTests()
        {
            _serviceMock = new Mock<IColecaoService>();
            _loggerMock = new Mock<ILogger<ColecaoController>>();
            _controller = new ColecaoController(_serviceMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task GetAll_DeveRetornarOkComLista()
        {
            var colecoes = new List<Colecao>
            {
                new() { Id = Guid.NewGuid(), Nome = "Coleção 1", Ano = 2024 },
                new() { Id = Guid.NewGuid(), Nome = "Coleção 2", Ano = 2023 }
            };
            _serviceMock.Setup(s => s.GetAllAsync()).ReturnsAsync(colecoes);

            var result = await _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(colecoes, okResult.Value);
        }

        [Fact]
        public async Task GetById_DeveRetornarOkSeEncontrado()
        {
            var id = Guid.NewGuid();
            var colecao = new Colecao { Id = id, Nome = "Coleção Teste", Ano = 2024 };
            _serviceMock.Setup(s => s.GetByIdAsync(id)).ReturnsAsync(colecao);

            var result = await _controller.GetById(id);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(colecao, okResult.Value);
        }

        [Fact]
        public async Task GetById_DeveRetornarNotFoundSeNaoEncontrado()
        {
            var id = Guid.NewGuid();
            _serviceMock.Setup(s => s.GetByIdAsync(id)).ReturnsAsync((Colecao)null);

            var result = await _controller.GetById(id);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Post_DeveRetornarOkSeSucesso()
        {
            var model = new Colecao { Id = Guid.NewGuid(), Nome = "Nova Coleção", Ano = 2025 };
            _serviceMock.Setup(s => s.AddAsync(model)).ReturnsAsync(true);

            var result = await _controller.Post(model);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Post_DeveRetornarBadRequestSeFalha()
        {
            var model = new Colecao { Id = Guid.NewGuid(), Nome = "Nova Coleção", Ano = 2025 };
            _serviceMock.Setup(s => s.AddAsync(model)).ReturnsAsync(false);

            var result = await _controller.Post(model);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Put_DeveRetornarOkSeSucesso()
        {
            var model = new Colecao { Id = Guid.NewGuid(), Nome = "Atualizada", Ano = 2025 };
            _serviceMock.Setup(s => s.UpdateAsync(model)).ReturnsAsync(true);

            var result = await _controller.Put(model);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Put_DeveRetornarBadRequestSeFalha()
        {
            var model = new Colecao { Id = Guid.NewGuid(), Nome = "Atualizada", Ano = 2025 };
            _serviceMock.Setup(s => s.UpdateAsync(model)).ReturnsAsync(false);

            var result = await _controller.Put(model);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Delete_DeveRetornarOkSeSucesso()
        {
            var id = Guid.NewGuid();
            _serviceMock.Setup(s => s.DeleteAsync(id)).ReturnsAsync(true);

            var result = await _controller.Delete(id);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Delete_DeveRetornarBadRequestSeFalha()
        {
            var id = Guid.NewGuid();
            _serviceMock.Setup(s => s.DeleteAsync(id)).ReturnsAsync(false);

            var result = await _controller.Delete(id);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task GetByFilterAsync_DeveRetornarOkComLista()
        {
            var nome = "Coleção";
            var colecoes = new List<Colecao>
            {
                new() { Id = Guid.NewGuid(), Nome = "Coleção 1", Ano = 2024 }
            };
            _serviceMock.Setup(s => s.GetByFilterAsync(It.Is<ColecaoFilter>(f => f.Nome == nome))).ReturnsAsync(colecoes);

            var result = await _controller.GetByFilterAsync(nome);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(colecoes, okResult.Value);
        }
    }
}