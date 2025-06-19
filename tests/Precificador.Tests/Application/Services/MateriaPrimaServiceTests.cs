using Moq;
using Precificador.Application.Model;
using Precificador.Application.Services;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository;

namespace Precificador.Tests.Application.Services
{
    public class MateriaPrimaServiceTests
    {
        private readonly Mock<IMateriaPrimaRepository> _repositoryMock;
        private readonly MateriaPrimaService _service;

        public MateriaPrimaServiceTests()
        {
            _repositoryMock = new Mock<IMateriaPrimaRepository>();
            _service = new MateriaPrimaService(_repositoryMock.Object);
        }

        [Fact]
        public void ConvertToEntity_DeveConverterModelParaEntity()
        {
            var model = new MateriaPrima
            {
                Id = Guid.NewGuid(),
                Nome = "Matéria Prima Teste",
                QtdPacote = 10,
                VlrPacote = 100,
                DataPreco = new DateTime(2024, 1, 1),
                GrupoId = Guid.NewGuid(),
                UnidadeMedidaId = Guid.NewGuid()
            };

            var entity = _service.InvokeConvertToEntity(model);

            Assert.Equal(model.Id, entity.Id);
            Assert.Equal(model.Nome, entity.Nome);
            Assert.Equal(model.QtdPacote, entity.QtdPacote);
            Assert.Equal(model.VlrPacote, entity.VlrPacote);
            Assert.Equal(model.DataPreco, entity.DataPreco);
            Assert.Equal(model.GrupoId, entity.GrupoId);
            Assert.Equal(model.UnidadeMedidaId, entity.UnidadeMedidaId);
        }

        [Fact]
        public void ConvertToModel_DeveConverterEntityParaModel()
        {
            var entity = new Domain.Entities.MateriaPrima
            {
                Id = Guid.NewGuid(),
                Nome = "Matéria Prima Entity",
                QtdPacote = 5,
                VlrPacote = 50,
                DataPreco = new DateTime(2023, 5, 10),
                GrupoId = Guid.NewGuid(),
                UnidadeMedidaId = Guid.NewGuid()
            };

            var model = _service.InvokeConvertToModel(entity);

            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Nome, model.Nome);
            Assert.Equal(entity.QtdPacote, model.QtdPacote);
            Assert.Equal(entity.VlrPacote, model.VlrPacote);
            Assert.Equal(entity.DataPreco, model.DataPreco);
            Assert.Equal(entity.VlrUnitario, model.VlrUnitario);
            Assert.Equal(entity.GrupoId, model.GrupoId);
            Assert.Equal(entity.UnidadeMedidaId, model.UnidadeMedidaId);
        }

        [Fact]
        public void UpdateEntityFromModel_DeveAtualizarEntityComDadosDoModel()
        {
            var entity = new Domain.Entities.MateriaPrima
            {
                Id = Guid.NewGuid(),
                Nome = "Antigo",
                QtdPacote = 1,
                VlrPacote = 1,
                DataPreco = new DateTime(2020, 1, 1),
                GrupoId = Guid.NewGuid(),
                UnidadeMedidaId = Guid.NewGuid()
            };
            var model = new MateriaPrima
            {
                Nome = "Novo",
                QtdPacote = 2,
                VlrPacote = 3,
                DataPreco = new DateTime(2025, 2, 2),
                GrupoId = Guid.NewGuid(),
                UnidadeMedidaId = Guid.NewGuid()
            };

            _service.InvokeUpdateEntityFromModel(entity, model);

            Assert.Equal(model.Nome, entity.Nome);
            Assert.Equal(model.QtdPacote, entity.QtdPacote);
            Assert.Equal(model.VlrPacote, entity.VlrPacote);
            Assert.Equal(model.DataPreco, entity.DataPreco);
            Assert.Equal(model.GrupoId, entity.GrupoId);
            Assert.Equal(model.UnidadeMedidaId, entity.UnidadeMedidaId);
        }

        [Fact]
        public async Task GetEntitiesByFilterAsync_DeveChamarRepositorioComFiltro()
        {
            var filter = new NomeFilter { Nome = "Filtro" };
            var entities = new List<Domain.Entities.MateriaPrima>
            {
                new() { Id = Guid.NewGuid(), Nome = "Matéria 1" }
            };
            _repositoryMock.Setup(r => r.GetByFilterAsync(filter)).ReturnsAsync(entities);

            var result = await _service.InvokeGetEntitiesByFilterAsync(filter);

            Assert.Single(result);
            Assert.Equal("Matéria 1", ((List<Domain.Entities.MateriaPrima>)result)[0].Nome);
            _repositoryMock.Verify(r => r.GetByFilterAsync(filter), Times.Once);
        }
    }

    public static class MateriaPrimaServiceTestExtensions
    {
        public static Domain.Entities.MateriaPrima? InvokeConvertToEntity(this MateriaPrimaService service, MateriaPrima model)
        {
            var methodInfo = typeof(MateriaPrimaService)
                .GetMethod("ConvertToEntity", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

            return methodInfo == null
                ? throw new InvalidOperationException("Method 'ConvertToEntity' not found in MateriaPrimaService.")
                : methodInfo.Invoke(service, [model]) as Domain.Entities.MateriaPrima;
        }

        public static MateriaPrima? InvokeConvertToModel(this MateriaPrimaService service, Domain.Entities.MateriaPrima entity)
        {
            var methodInfo = typeof(MateriaPrimaService)
                .GetMethod("ConvertToModel", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

            return methodInfo == null
                ? throw new InvalidOperationException("Method 'ConvertToModel' not found in MateriaPrimaService.")
                : methodInfo.Invoke(service, [entity]) as MateriaPrima;
        }

        public static void InvokeUpdateEntityFromModel(this MateriaPrimaService service, Domain.Entities.MateriaPrima entity, MateriaPrima model)
        {
            var methodInfo = typeof(MateriaPrimaService)
                .GetMethod("UpdateEntityFromModel", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic) ?? throw new InvalidOperationException("Method 'UpdateEntityFromModel' not found in MateriaPrimaService.");
            methodInfo.Invoke(service, [entity, model]);
        }

        public static Task<IEnumerable<Domain.Entities.MateriaPrima>> InvokeGetEntitiesByFilterAsync(this MateriaPrimaService service, NomeFilter filter)
        {
            var methodInfo = typeof(MateriaPrimaService)
                .GetMethod("GetEntitiesByFilterAsync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic) ?? throw new InvalidOperationException("Method 'GetEntitiesByFilterAsync' not found in MateriaPrimaService.");
            var result = methodInfo.Invoke(service, [filter]);

            return result is Task<IEnumerable<Domain.Entities.MateriaPrima>> taskResult
                ? taskResult
                : throw new InvalidOperationException("Method 'GetEntitiesByFilterAsync' did not return the expected type.");
        }
    }
}