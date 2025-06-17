using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Precificador.Application.Model;
using Precificador.Application.Services;
using Precificador.Domain.Filters;
using Precificador.WebApi.Controllers;

namespace Precificador.Tests.WebApi.Controllers
{
    public class MateriaPrimaControllerTests
    {
        private readonly Mock<IMateriaPrimaService> _serviceMock;
        private readonly Mock<ILogger> _loggerMock;
        private readonly MateriaPrimaController _controller;

        public MateriaPrimaControllerTests()
        {
            _serviceMock = new Mock<IMateriaPrimaService>();
            _loggerMock = new Mock<ILogger>();
            _controller = new MateriaPrimaController(_serviceMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task GetAll_DeveRetornarOkComLista()
        {
            var materias = new List<MateriaPrima>
            {
                new MateriaPrima { Id = Guid.NewGuid(), Nome = "Matéria 1", QtdPacote = 10, VlrPacote = 100, GrupoId = Guid.NewGuid(), UnidadeMedidaId = Guid.NewGuid() },
                new MateriaPrima { Id = Guid.NewGuid(), Nome = "Matéria 2", QtdPacote = 5, VlrPacote = 50, GrupoId = Guid.NewGuid(), UnidadeMedidaId = Guid.NewGuid() }
            };
            _serviceMock.Setup(s => s.GetAllAsync()).ReturnsAsync(materias);

            var result = await _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(materias, okResult.Value);
        }

        [Fact]
        public async Task GetById_DeveRetornarOkSeEncontrado()
        {
            var id = Guid.NewGuid();
            var materia = new MateriaPrima { Id = id, Nome = "Matéria Teste", QtdPacote = 10, VlrPacote = 100, GrupoId = Guid.NewGuid(), UnidadeMedidaId = Guid.NewGuid() };
            _serviceMock.Setup(s => s.GetByIdAsync(id)).ReturnsAsync(materia);

            var result = await _controller.GetById(id);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(materia, okResult.Value);
        }

        [Fact]
        public async Task GetById_DeveRetornarNotFoundSeNaoEncontrado()
        {
            var id = Guid.NewGuid();
            _serviceMock.Setup(s => s.GetByIdAsync(id)).ReturnsAsync((MateriaPrima)null);

            var result = await _controller.GetById(id);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Post_DeveRetornarOkSeSucesso()
        {
            var model = new MateriaPrima { Id = Guid.NewGuid(), Nome = "Nova Matéria", QtdPacote = 10, VlrPacote = 100, GrupoId = Guid.NewGuid(), UnidadeMedidaId = Guid.NewGuid() };
            _serviceMock.Setup(s => s.AddAsync(model)).ReturnsAsync(true);

            var result = await _controller.Post(model);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Post_DeveRetornarBadRequestSeFalha()
        {
            var model = new MateriaPrima { Id = Guid.NewGuid(), Nome = "Nova Matéria", QtdPacote = 10, VlrPacote = 100, GrupoId = Guid.NewGuid(), UnidadeMedidaId = Guid.NewGuid() };
            _serviceMock.Setup(s => s.AddAsync(model)).ReturnsAsync(false);

            var result = await _controller.Post(model);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Put_DeveRetornarOkSeSucesso()
        {
            var model = new MateriaPrima { Id = Guid.NewGuid(), Nome = "Atualizada", QtdPacote = 20, VlrPacote = 200, GrupoId = Guid.NewGuid(), UnidadeMedidaId = Guid.NewGuid() };
            _serviceMock.Setup(s => s.UpdateAsync(model)).ReturnsAsync(true);

            var result = await _controller.Put(model);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Put_DeveRetornarBadRequestSeFalha()
        {
            var model = new MateriaPrima { Id = Guid.NewGuid(), Nome = "Atualizada", QtdPacote = 20, VlrPacote = 200, GrupoId = Guid.NewGuid(), UnidadeMedidaId = Guid.NewGuid() };
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
            var nome = "Matéria";
            var materias = new List<MateriaPrima>
            {
                new MateriaPrima { Id = Guid.NewGuid(), Nome = "Matéria 1", QtdPacote = 10, VlrPacote = 100, GrupoId = Guid.NewGuid(), UnidadeMedidaId = Guid.NewGuid() }
            };
            _serviceMock.Setup(s => s.GetByFilterAsync(It.Is<NomeFilter>(f => f.Nome == nome))).ReturnsAsync(materias);

            var result = await _controller.GetByFilterAsync(nome);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(materias, okResult.Value);
        }
    }
}