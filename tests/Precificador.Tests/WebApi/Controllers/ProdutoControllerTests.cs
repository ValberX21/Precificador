using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Precificador.Application.Model;
using Precificador.Application.Services;
using Precificador.Domain.Filters;
using Precificador.WebApi.Controllers;

namespace Precificador.Tests.WebApi.Controllers
{
    public class ProdutoControllerTests
    {
        private readonly Mock<IProdutoService> _serviceMock;
        private readonly Mock<ILogger<ProdutoController>> _loggerMock;
        private readonly ProdutoController _controller;

        public ProdutoControllerTests()
        {
            _serviceMock = new Mock<IProdutoService>();
            _loggerMock = new Mock<ILogger<ProdutoController>>();
            _controller = new ProdutoController(_serviceMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task GetAll_DeveRetornarOkComLista()
        {
            var produtos = new List<Produto>
            {
                new() { Id = Guid.NewGuid(), Nome = "Produto 1", ColecaoId = Guid.NewGuid(), Margem = 0.2m },
                new() { Id = Guid.NewGuid(), Nome = "Produto 2", ColecaoId = Guid.NewGuid(), Margem = 0.3m }
            };
            _serviceMock.Setup(s => s.GetAllAsync()).ReturnsAsync(produtos);

            var result = await _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(produtos, okResult.Value);
        }

        [Fact]
        public async Task GetById_DeveRetornarOkSeEncontrado()
        {
            var id = Guid.NewGuid();
            var produto = new Produto { Id = id, Nome = "Produto Teste", ColecaoId = Guid.NewGuid(), Margem = 0.5m };
            _serviceMock.Setup(s => s.GetByIdAsync(id)).ReturnsAsync(produto);

            var result = await _controller.GetById(id);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(produto, okResult.Value);
        }

        [Fact]
        public async Task GetById_DeveRetornarNotFoundSeNaoEncontrado()
        {
            var id = Guid.NewGuid();
            _serviceMock.Setup(s => s.GetByIdAsync(id)).ReturnsAsync((Produto?)null);

            var result = await _controller.GetById(id);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Post_DeveRetornarOkSeSucesso()
        {
            var model = new Produto { Id = Guid.NewGuid(), Nome = "Novo Produto", ColecaoId = Guid.NewGuid(), Margem = 0.4m };
            _serviceMock.Setup(s => s.AddAsync(model)).ReturnsAsync(true);

            var result = await _controller.Post(model);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Post_DeveRetornarBadRequestSeFalha()
        {
            var model = new Produto { Id = Guid.NewGuid(), Nome = "Novo Produto", ColecaoId = Guid.NewGuid(), Margem = 0.4m };
            _serviceMock.Setup(s => s.AddAsync(model)).ReturnsAsync(false);

            var result = await _controller.Post(model);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Put_DeveRetornarOkSeSucesso()
        {
            var model = new Produto { Id = Guid.NewGuid(), Nome = "Atualizado", ColecaoId = Guid.NewGuid(), Margem = 0.6m };
            _serviceMock.Setup(s => s.UpdateAsync(model)).ReturnsAsync(true);

            var result = await _controller.Put(model);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Put_DeveRetornarBadRequestSeFalha()
        {
            var model = new Produto { Id = Guid.NewGuid(), Nome = "Atualizado", ColecaoId = Guid.NewGuid(), Margem = 0.6m };
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
            var nome = "Produto";
            var produtos = new List<Produto>
            {
                new() { Id = Guid.NewGuid(), Nome = "Produto 1", ColecaoId = Guid.NewGuid(), Margem = 0.2m }
            };
            _serviceMock.Setup(s => s.GetByFilterAsync(It.Is<NomeFilter>(f => f.Nome == nome))).ReturnsAsync(produtos);

            var result = await _controller.GetByFilterAsync(nome);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(produtos, okResult.Value);
        }
    }
}