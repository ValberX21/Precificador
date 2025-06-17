using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Precificador.Application.Model;
using Precificador.Application.Services;
using Precificador.Domain.Filters;
using Precificador.WebApi.Controllers;

namespace Precificador.Tests.WebApi.Controllers
{
    public class ProdutoMateriaPrimaControllerTests
    {
        private readonly Mock<IProdutoMateriaPrimaService> _serviceMock;
        private readonly Mock<ILogger<ProdutoMateriaPrimaController>> _loggerMock;
        private readonly ProdutoMateriaPrimaController _controller;

        public ProdutoMateriaPrimaControllerTests()
        {
            _serviceMock = new Mock<IProdutoMateriaPrimaService>();
            _loggerMock = new Mock<ILogger<ProdutoMateriaPrimaController>>();
            _controller = new ProdutoMateriaPrimaController(_serviceMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task GetAll_DeveRetornarOkComLista()
        {
            var lista = new List<ProdutoMateriaPrima>
            {
                new ProdutoMateriaPrima { Id = Guid.NewGuid(), ProdutoId = Guid.NewGuid(), MateriaPrimaId = Guid.NewGuid(), Quantidade = 2.5m },
                new ProdutoMateriaPrima { Id = Guid.NewGuid(), ProdutoId = Guid.NewGuid(), MateriaPrimaId = Guid.NewGuid(), Quantidade = 1.0m }
            };
            _serviceMock.Setup(s => s.GetAllAsync()).ReturnsAsync(lista);

            var result = await _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(lista, okResult.Value);
        }

        [Fact]
        public async Task GetById_DeveRetornarOkSeEncontrado()
        {
            var id = Guid.NewGuid();
            var item = new ProdutoMateriaPrima { Id = id, ProdutoId = Guid.NewGuid(), MateriaPrimaId = Guid.NewGuid(), Quantidade = 3.0m };
            _serviceMock.Setup(s => s.GetByIdAsync(id)).ReturnsAsync(item);

            var result = await _controller.GetById(id);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(item, okResult.Value);
        }

        [Fact]
        public async Task GetById_DeveRetornarNotFoundSeNaoEncontrado()
        {
            var id = Guid.NewGuid();
            _serviceMock.Setup(s => s.GetByIdAsync(id)).ReturnsAsync((ProdutoMateriaPrima)null);

            var result = await _controller.GetById(id);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Post_DeveRetornarOkSeSucesso()
        {
            var model = new ProdutoMateriaPrima { Id = Guid.NewGuid(), ProdutoId = Guid.NewGuid(), MateriaPrimaId = Guid.NewGuid(), Quantidade = 5.0m };
            _serviceMock.Setup(s => s.AddAsync(model)).ReturnsAsync(true);

            var result = await _controller.Post(model);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Post_DeveRetornarBadRequestSeFalha()
        {
            var model = new ProdutoMateriaPrima { Id = Guid.NewGuid(), ProdutoId = Guid.NewGuid(), MateriaPrimaId = Guid.NewGuid(), Quantidade = 5.0m };
            _serviceMock.Setup(s => s.AddAsync(model)).ReturnsAsync(false);

            var result = await _controller.Post(model);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Put_DeveRetornarOkSeSucesso()
        {
            var model = new ProdutoMateriaPrima { Id = Guid.NewGuid(), ProdutoId = Guid.NewGuid(), MateriaPrimaId = Guid.NewGuid(), Quantidade = 7.0m };
            _serviceMock.Setup(s => s.UpdateAsync(model)).ReturnsAsync(true);

            var result = await _controller.Put(model);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Put_DeveRetornarBadRequestSeFalha()
        {
            var model = new ProdutoMateriaPrima { Id = Guid.NewGuid(), ProdutoId = Guid.NewGuid(), MateriaPrimaId = Guid.NewGuid(), Quantidade = 7.0m };
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
            var nome = "Filtro";
            var lista = new List<ProdutoMateriaPrima>
            {
                new ProdutoMateriaPrima { Id = Guid.NewGuid(), ProdutoId = Guid.NewGuid(), MateriaPrimaId = Guid.NewGuid(), Quantidade = 2.0m }
            };
            _serviceMock.Setup(s => s.GetByFilterAsync(It.Is<ProdutoMateriaPrimaFilter>(f => f.ProdutoNome == nome || f.MateriaPrimaNome == nome))).ReturnsAsync(lista);

            var result = await _controller.GetByFilterAsync(nome);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(lista, okResult.Value);
        }
    }
}