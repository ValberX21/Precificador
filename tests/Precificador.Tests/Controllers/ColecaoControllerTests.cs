using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Precificador.Application.Model;
using Precificador.Application.Services;
using Precificador.WebApi.Controllers;

namespace Precificador.Tests.Controllers
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
        public async Task GetAll_ShouldReturnOk_WhenFound()
        {
            var colecoes = new List<Colecao> { new Colecao { Id = Guid.NewGuid(), Nome = "A" } };
            _serviceMock.Setup(s => s.GetAllAsync()).ReturnsAsync(colecoes);

            var result = await _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(colecoes, okResult.Value);
        }

        [Fact]
        public async Task GetAll_ShouldReturnNoContent_WhenNone()
        {
            _serviceMock.Setup(s => s.GetAllAsync()).ReturnsAsync(new List<Colecao>());

            var result = await _controller.GetAll();

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task GetAll_ShouldReturnBadRequest_OnException()
        {
            _serviceMock.Setup(s => s.GetAllAsync()).ThrowsAsync(new Exception());

            var result = await _controller.GetAll();

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task GetById_ShouldReturnOk_WhenFound()
        {
            var colecao = new Colecao { Id = Guid.NewGuid(), Nome = "A" };
            _serviceMock.Setup(s => s.GetByIdAsync(colecao.Id)).ReturnsAsync(colecao);

            var result = await _controller.GetById(colecao.Id);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(colecao, okResult.Value);
        }

        [Fact]
        public async Task GetById_ShouldReturnNoContent_WhenNotFound()
        {
            _serviceMock.Setup(s => s.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Colecao)null);

            var result = await _controller.GetById(Guid.NewGuid());

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task GetById_ShouldReturnBadRequest_OnException()
        {
            _serviceMock.Setup(s => s.GetByIdAsync(It.IsAny<Guid>())).ThrowsAsync(new Exception());

            var result = await _controller.GetById(Guid.NewGuid());

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task GetAllByName_ShouldReturnOk_WhenFound()
        {
            var colecoes = new List<Colecao> { new Colecao { Id = Guid.NewGuid(), Nome = "X" } };
            _serviceMock.Setup(s => s.GetAllByNameAsync("X")).ReturnsAsync(colecoes);

            var result = await _controller.GetAllByName("X");

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(colecoes, okResult.Value);
        }

        [Fact]
        public async Task GetAllByName_ShouldReturnNoContent_WhenNone()
        {
            _serviceMock.Setup(s => s.GetAllByNameAsync(It.IsAny<string>())).ReturnsAsync(new List<Colecao>());

            var result = await _controller.GetAllByName("X");

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task GetAllByName_ShouldReturnBadRequest_OnException()
        {
            _serviceMock.Setup(s => s.GetAllByNameAsync(It.IsAny<string>())).ThrowsAsync(new Exception());

            var result = await _controller.GetAllByName("X");

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Post_ShouldReturnOk_WhenSuccess()
        {
            var colecao = new Colecao { Id = Guid.NewGuid(), Nome = "A" };
            _serviceMock.Setup(s => s.AddAsync(colecao)).ReturnsAsync(true);

            var result = await _controller.Post(colecao);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.True((bool)okResult.Value);
        }

        [Fact]
        public async Task Post_ShouldReturnBadRequest_OnException()
        {
            _serviceMock.Setup(s => s.AddAsync(It.IsAny<Colecao>())).ThrowsAsync(new Exception());

            var result = await _controller.Post(new Colecao());

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Put_ShouldReturnOk_WhenUpdated()
        {
            var colecao = new Colecao { Id = Guid.NewGuid(), Nome = "A" };
            _serviceMock.Setup(s => s.UpdateAsync(colecao)).ReturnsAsync(true);

            var result = await _controller.Put(colecao);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.True((bool)okResult.Value);
        }

        [Fact]
        public async Task Put_ShouldReturnNoContent_WhenNotUpdated()
        {
            _serviceMock.Setup(s => s.UpdateAsync(It.IsAny<Colecao>())).ReturnsAsync(false);

            var result = await _controller.Put(new Colecao());

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Put_ShouldReturnBadRequest_OnException()
        {
            _serviceMock.Setup(s => s.UpdateAsync(It.IsAny<Colecao>())).ThrowsAsync(new Exception());

            var result = await _controller.Put(new Colecao());

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Delete_ShouldReturnOk_WhenDeleted()
        {
            var id = Guid.NewGuid();
            _serviceMock.Setup(s => s.DeleteAsync(id)).ReturnsAsync(true);

            var result = await _controller.Delete(id);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.True((bool)okResult.Value);
        }

        [Fact]
        public async Task Delete_ShouldReturnNoContent_WhenNotDeleted()
        {
            _serviceMock.Setup(s => s.DeleteAsync(It.IsAny<Guid>())).ReturnsAsync(false);

            var result = await _controller.Delete(Guid.NewGuid());

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_ShouldReturnBadRequest_OnException()
        {
            _serviceMock.Setup(s => s.DeleteAsync(It.IsAny<Guid>())).ThrowsAsync(new Exception());

            var result = await _controller.Delete(Guid.NewGuid());

            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}