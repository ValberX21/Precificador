using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Precificador.Application.Model;
using Precificador.Application.Services;
using Precificador.Domain.Filters;
using Precificador.WebApi.Controllers;

namespace Precificador.Tests.WebApi.Controllers
{
    public class GrupoControllerTests
    {
        private readonly Mock<IGrupoService> _serviceMock;
        private readonly Mock<ILogger> _loggerMock;
        private readonly GrupoController _controller;

        public GrupoControllerTests()
        {
            _serviceMock = new Mock<IGrupoService>();
            _loggerMock = new Mock<ILogger>();
            _controller = new GrupoController(_serviceMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task GetAll_DeveRetornarOkComLista()
        {
            var grupos = new List<Grupo>
            {
                new Grupo { Id = Guid.NewGuid(), Nome = "Grupo 1" },
                new Grupo { Id = Guid.NewGuid(), Nome = "Grupo 2" }
            };
            _serviceMock.Setup(s => s.GetAllAsync()).ReturnsAsync(grupos);

            var result = await _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(grupos, okResult.Value);
        }

        [Fact]
        public async Task GetById_DeveRetornarOkSeEncontrado()
        {
            var id = Guid.NewGuid();
            var grupo = new Grupo { Id = id, Nome = "Grupo Teste" };
            _serviceMock.Setup(s => s.GetByIdAsync(id)).ReturnsAsync(grupo);

            var result = await _controller.GetById(id);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(grupo, okResult.Value);
        }

        [Fact]
        public async Task GetById_DeveRetornarNotFoundSeNaoEncontrado()
        {
            var id = Guid.NewGuid();
            _serviceMock.Setup(s => s.GetByIdAsync(id)).ReturnsAsync((Grupo)null);

            var result = await _controller.GetById(id);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Post_DeveRetornarOkSeSucesso()
        {
            var model = new Grupo { Id = Guid.NewGuid(), Nome = "Novo Grupo" };
            _serviceMock.Setup(s => s.AddAsync(model)).ReturnsAsync(true);

            var result = await _controller.Post(model);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Post_DeveRetornarBadRequestSeFalha()
        {
            var model = new Grupo { Id = Guid.NewGuid(), Nome = "Novo Grupo" };
            _serviceMock.Setup(s => s.AddAsync(model)).ReturnsAsync(false);

            var result = await _controller.Post(model);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Put_DeveRetornarOkSeSucesso()
        {
            var model = new Grupo { Id = Guid.NewGuid(), Nome = "Atualizado" };
            _serviceMock.Setup(s => s.UpdateAsync(model)).ReturnsAsync(true);

            var result = await _controller.Put(model);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Put_DeveRetornarBadRequestSeFalha()
        {
            var model = new Grupo { Id = Guid.NewGuid(), Nome = "Atualizado" };
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
            var nome = "Grupo";
            var grupos = new List<Grupo>
            {
                new Grupo { Id = Guid.NewGuid(), Nome = "Grupo 1" }
            };
            _serviceMock.Setup(s => s.GetByFilterAsync(It.Is<NomeFilter>(f => f.Nome == nome))).ReturnsAsync(grupos);

            var result = await _controller.GetByFilterAsync(nome);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(grupos, okResult.Value);
        }
    }
}