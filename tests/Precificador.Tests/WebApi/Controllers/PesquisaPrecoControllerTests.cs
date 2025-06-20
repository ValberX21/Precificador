using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Precificador.Application.Model;
using Precificador.Application.Services;
using Precificador.Domain.Filters;
using Precificador.WebApi.Controllers;

namespace Precificador.Tests.WebApi.Controllers
{
    public class PesquisaPrecoControllerTests
    {
        private readonly Mock<IPesquisaPrecoService> _serviceMock;
        private readonly Mock<ILogger<PesquisaPrecoController>> _loggerMock;
        private readonly PesquisaPrecoController _controller;

        public PesquisaPrecoControllerTests()
        {
            _serviceMock = new Mock<IPesquisaPrecoService>();
            _loggerMock = new Mock<ILogger<PesquisaPrecoController>>();
            _controller = new PesquisaPrecoController(_serviceMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task GetAll_DeveRetornarOkComLista()
        {
            var pesquisas = new List<PesquisaPreco>
            {
                new() { Id = Guid.NewGuid(), ProdutoId = Guid.NewGuid(), Local = "Mercado 1", Valor = 10, DataPesquisa = DateTime.Now },
                new() { Id = Guid.NewGuid(), ProdutoId = Guid.NewGuid(), Local = "Mercado 2", Valor = 20, DataPesquisa = DateTime.Now }
            };
            _serviceMock.Setup(s => s.GetAllAsync()).ReturnsAsync(pesquisas);

            var result = await _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(pesquisas, okResult.Value);
        }

        [Fact]
        public async Task GetById_DeveRetornarOkSeEncontrado()
        {
            var id = Guid.NewGuid();
            var pesquisa = new PesquisaPreco { Id = id, ProdutoId = Guid.NewGuid(), Local = "Mercado", Valor = 15, DataPesquisa = DateTime.Now };
            _serviceMock.Setup(s => s.GetByIdAsync(id)).ReturnsAsync(pesquisa);

            var result = await _controller.GetById(id);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(pesquisa, okResult.Value);
        }

        [Fact]
        public async Task GetById_DeveRetornarNotFoundSeNaoEncontrado()
        {
            var id = Guid.NewGuid();
            _serviceMock.Setup(s => s.GetByIdAsync(id)).ReturnsAsync((PesquisaPreco?)null);

            var result = await _controller.GetById(id);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Post_DeveRetornarOkSeSucesso()
        {
            var model = new PesquisaPreco { Id = Guid.NewGuid(), ProdutoId = Guid.NewGuid(), Local = "Novo", Valor = 30, DataPesquisa = DateTime.Now };
            _serviceMock.Setup(s => s.AddAsync(model)).ReturnsAsync(true);

            var result = await _controller.Post(model);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Post_DeveRetornarBadRequestSeFalha()
        {
            var model = new PesquisaPreco { Id = Guid.NewGuid(), ProdutoId = Guid.NewGuid(), Local = "Novo", Valor = 30, DataPesquisa = DateTime.Now };
            _serviceMock.Setup(s => s.AddAsync(model)).ReturnsAsync(false);

            var result = await _controller.Post(model);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Put_DeveRetornarOkSeSucesso()
        {
            var model = new PesquisaPreco { Id = Guid.NewGuid(), ProdutoId = Guid.NewGuid(), Local = "Atualizado", Valor = 40, DataPesquisa = DateTime.Now };
            _serviceMock.Setup(s => s.UpdateAsync(model)).ReturnsAsync(true);

            var result = await _controller.Put(model);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Put_DeveRetornarBadRequestSeFalha()
        {
            var model = new PesquisaPreco { Id = Guid.NewGuid(), ProdutoId = Guid.NewGuid(), Local = "Atualizado", Valor = 40, DataPesquisa = DateTime.Now };
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
            var nome = "Mercado";
            var pesquisas = new List<PesquisaPreco>
            {
                new() { Id = Guid.NewGuid(), ProdutoId = Guid.NewGuid(), Local = "Mercado", Valor = 10, DataPesquisa = DateTime.Now }
            };
            _serviceMock.Setup(s => s.GetByFilterAsync(It.Is<PesquisaPrecoFilter>(f => f.Local == nome || f.ProdutoNome == nome))).ReturnsAsync(pesquisas);

            var result = await _controller.GetByFilterAsync(nome);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(pesquisas, okResult.Value);
        }
    }
}