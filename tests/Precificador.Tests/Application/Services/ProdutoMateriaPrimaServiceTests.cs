using Moq;
using Precificador.Application.Model;
using Precificador.Application.Services;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository;

namespace Precificador.Tests.Application.Services
{
    public class ProdutoMateriaPrimaServiceTests
    {
        private readonly Mock<IProdutoMateriaPrimaRepository> _repositoryMock;
        private readonly ProdutoMateriaPrimaService _service;

        public ProdutoMateriaPrimaServiceTests()
        {
            _repositoryMock = new Mock<IProdutoMateriaPrimaRepository>();
            _service = new ProdutoMateriaPrimaService(_repositoryMock.Object);
        }

        [Fact]
        public void ConvertToEntity_DeveConverterModelParaEntity()
        {
            var model = new ProdutoMateriaPrima
            {
                Id = Guid.NewGuid(),
                ProdutoId = Guid.NewGuid(),
                MateriaPrimaId = Guid.NewGuid(),
                Quantidade = 5.5m
            };

            var entity = _service.InvokeConvertToEntity(model);

            Assert.Equal(model.Id, entity.Id);
            Assert.Equal(model.ProdutoId, entity.ProdutoId);
            Assert.Equal(model.MateriaPrimaId, entity.MateriaPrimaId);
            Assert.Equal(model.Quantidade, entity.Quantidade);
        }

        [Fact]
        public void ConvertToModel_DeveConverterEntityParaModel()
        {
            var entity = new Domain.Entities.ProdutoMateriaPrima
            {
                Id = Guid.NewGuid(),
                ProdutoId = Guid.NewGuid(),
                MateriaPrimaId = Guid.NewGuid(),
                Quantidade = 10.0m
            };

            var model = _service.InvokeConvertToModel(entity);

            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.ProdutoId, model.ProdutoId);
            Assert.Equal(entity.MateriaPrimaId, model.MateriaPrimaId);
            Assert.Equal(entity.Quantidade, model.Quantidade);
        }

        [Fact]
        public void UpdateEntityFromModel_DeveAtualizarEntityComDadosDoModel()
        {
            var entity = new Domain.Entities.ProdutoMateriaPrima
            {
                Id = Guid.NewGuid(),
                ProdutoId = Guid.NewGuid(),
                MateriaPrimaId = Guid.NewGuid(),
                Quantidade = 1.0m
            };
            var model = new ProdutoMateriaPrima
            {
                ProdutoId = Guid.NewGuid(),
                MateriaPrimaId = Guid.NewGuid(),
                Quantidade = 7.7m
            };

            _service.InvokeUpdateEntityFromModel(entity, model);

            Assert.Equal(model.ProdutoId, entity.ProdutoId);
            Assert.Equal(model.MateriaPrimaId, entity.MateriaPrimaId);
            Assert.Equal(model.Quantidade, entity.Quantidade);
        }

        [Fact]
        public async Task GetEntitiesByFilterAsync_DeveChamarRepositorioComFiltro()
        {
            var filter = new ProdutoMateriaPrimaFilter { ProdutoId = Guid.NewGuid(), MateriaPrimaId = Guid.NewGuid() };
            var entities = new List<Domain.Entities.ProdutoMateriaPrima>
            {
                new Domain.Entities.ProdutoMateriaPrima { Id = Guid.NewGuid(), ProdutoId = filter.ProdutoId, MateriaPrimaId = filter.MateriaPrimaId, Quantidade = 2.0m }
            };
            _repositoryMock.Setup(r => r.GetByFilterAsync(filter)).ReturnsAsync(entities);

            var result = await _service.InvokeGetEntitiesByFilterAsync(filter);

            Assert.Single(result);
            Assert.Equal(filter.ProdutoId, ((List<Domain.Entities.ProdutoMateriaPrima>)result)[0].ProdutoId);
            Assert.Equal(filter.MateriaPrimaId, ((List<Domain.Entities.ProdutoMateriaPrima>)result)[0].MateriaPrimaId);
            _repositoryMock.Verify(r => r.GetByFilterAsync(filter), Times.Once);
        }
    }

    // Métodos auxiliares para acessar membros protegidos via reflexão
    public static class ProdutoMateriaPrimaServiceTestExtensions
    {
        public static Domain.Entities.ProdutoMateriaPrima InvokeConvertToEntity(this ProdutoMateriaPrimaService service, ProdutoMateriaPrima model)
            => (Domain.Entities.ProdutoMateriaPrima)typeof(ProdutoMateriaPrimaService)
                .GetMethod("ConvertToEntity", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .Invoke(service, new object[] { model });

        public static ProdutoMateriaPrima InvokeConvertToModel(this ProdutoMateriaPrimaService service, Domain.Entities.ProdutoMateriaPrima entity)
            => (ProdutoMateriaPrima)typeof(ProdutoMateriaPrimaService)
                .GetMethod("ConvertToModel", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .Invoke(service, new object[] { entity });

        public static void InvokeUpdateEntityFromModel(this ProdutoMateriaPrimaService service, Domain.Entities.ProdutoMateriaPrima entity, ProdutoMateriaPrima model)
            => typeof(ProdutoMateriaPrimaService)
                .GetMethod("UpdateEntityFromModel", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .Invoke(service, new object[] { entity, model });

        public static Task<IEnumerable<Domain.Entities.ProdutoMateriaPrima>> InvokeGetEntitiesByFilterAsync(this ProdutoMateriaPrimaService service, ProdutoMateriaPrimaFilter filter)
            => (Task<IEnumerable<Domain.Entities.ProdutoMateriaPrima>>)typeof(ProdutoMateriaPrimaService)
                .GetMethod("GetEntitiesByFilterAsync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .Invoke(service, new object[] { filter });
    }
}