using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Precificador.Application.Model;
using Precificador.Application.Services;
using Precificador.Domain.Filters;
using Precificador.WebApi.Controllers;

namespace Precificador.Tests.WebApi.Controllers
{
    public class UnidadeMedidaControllerTests
    {
        private readonly Mock<IUnidadeMedidaService> _serviceMock;
        private readonly Mock<ILogger<UnidadeMedidaController>> _loggerMock;
        private readonly UnidadeMedidaController _controller;

        public UnidadeMedidaControllerTests()
        {
            _serviceMock = new Mock<IUnidadeMedidaService>();
            _loggerMock = new Mock<ILogger<UnidadeMedidaController>>();
            _controller = new UnidadeMedidaController(_serviceMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task GetAll_DeveRetornarOkComLista()
        {
            var unidades = new List<UnidadeMedida>
            {
                new() { Id = Guid.NewGuid(), Nome = "Litro", Abreviacao = "L" },
                new() { Id = Guid.NewGuid(), Nome = "Quilo", Abreviacao = "Kg" }
            };
            _serviceMock.Setup(s => s.GetAllAsync()).ReturnsAsync(unidades);

            var result = await _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(unidades, okResult.Value);
        }

        [Fact]
        public async Task GetById_DeveRetornarOkSeEncontrado()
        {
            var id = Guid.NewGuid();
            var unidade = new UnidadeMedida { Id = id, Nome = "Litro", Abreviacao = "L" };
            _serviceMock.Setup(s => s.GetByIdAsync(id)).ReturnsAsync(unidade);

            var result = await _controller.GetById(id);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(unidade, okResult.Value);
        }

        [Fact]
        public async Task GetById_DeveRetornarNotFoundSeNaoEncontrado()
        {
            var id = Guid.NewGuid();
            _serviceMock.Setup(s => s.GetByIdAsync(id)).ReturnsAsync((UnidadeMedida?)null!);

            var result = await _controller.GetById(id);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Post_DeveRetornarOkSeSucesso()
        {
            var model = new UnidadeMedida { Id = Guid.NewGuid(), Nome = "Metro", Abreviacao = "m" };
            _serviceMock.Setup(s => s.AddAsync(model)).ReturnsAsync(true);

            var result = await _controller.Post(model);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Post_DeveRetornarBadRequestSeFalha()
        {
            var model = new UnidadeMedida { Id = Guid.NewGuid(), Nome = "Metro", Abreviacao = "m" };
            _serviceMock.Setup(s => s.AddAsync(model)).ReturnsAsync(false);

            var result = await _controller.Post(model);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Put_DeveRetornarOkSeSucesso()
        {
            var model = new UnidadeMedida { Id = Guid.NewGuid(), Nome = "Atualizada", Abreviacao = "A" };
            _serviceMock.Setup(s => s.UpdateAsync(model)).ReturnsAsync(true);

            var result = await _controller.Put(model);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Put_DeveRetornarBadRequestSeFalha()
        {
            var model = new UnidadeMedida { Id = Guid.NewGuid(), Nome = "Atualizada", Abreviacao = "A" };
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
            var nome = "Litro";
            var unidades = new List<UnidadeMedida>
            {
                new() { Id = Guid.NewGuid(), Nome = "Litro", Abreviacao = "L" }
            };
            _serviceMock.Setup(s => s.GetByFilterAsync(It.Is<NomeFilter>(f => f.Nome == nome))).ReturnsAsync(unidades);

            var result = await _controller.GetByFilterAsync(nome);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(unidades, okResult.Value);
        }
    }
}