using Moq;
using Precificador.Application.Model;
using Precificador.Application.Services;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository;

namespace Precificador.Tests.Application.Services
{
    public class UnidadeMedidaServiceTests
    {
        private readonly Mock<IUnidadeMedidaRepository> _repositoryMock;
        private readonly UnidadeMedidaService _service;

        public UnidadeMedidaServiceTests()
        {
            _repositoryMock = new Mock<IUnidadeMedidaRepository>();
            _service = new UnidadeMedidaService(_repositoryMock.Object);
        }

        [Fact]
        public void ConvertToEntity_DeveConverterModelParaEntity()
        {
            var model = new UnidadeMedida
            {
                Id = Guid.NewGuid(),
                Nome = "Litro",
                Abreviacao = "L"
            };

            var entity = _service.InvokeConvertToEntity(model);

            Assert.Equal(model.Id, entity.Id);
            Assert.Equal(model.Nome, entity.Nome);
            Assert.Equal(model.Abreviacao, entity.Abrebiacao);
        }

        [Fact]
        public void ConvertToModel_DeveConverterEntityParaModel()
        {
            var entity = new Domain.Entities.UnidadeMedida
            {
                Id = Guid.NewGuid(),
                Nome = "Quilograma",
                Abrebiacao = "Kg"
            };

            var model = _service.InvokeConvertToModel(entity);

            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Nome, model.Nome);
            Assert.Equal(entity.Abrebiacao, model.Abreviacao);
        }

        [Fact]
        public void UpdateEntityFromModel_DeveAtualizarEntityComDadosDoModel()
        {
            var entity = new Domain.Entities.UnidadeMedida
            {
                Id = Guid.NewGuid(),
                Nome = "Antigo",
                Abrebiacao = "A"
            };
            var model = new UnidadeMedida
            {
                Nome = "Novo",
                Abreviacao = "N"
            };

            _service.InvokeUpdateEntityFromModel(entity, model);

            Assert.Equal(model.Nome, entity.Nome);
            Assert.Equal(model.Abreviacao, entity.Abrebiacao);
        }

        [Fact]
        public async Task GetEntitiesByFilterAsync_DeveChamarRepositorioComFiltro()
        {
            var filter = new NomeFilter { Nome = "Filtro" };
            var entities = new List<Domain.Entities.UnidadeMedida>
            {
                new Domain.Entities.UnidadeMedida { Id = Guid.NewGuid(), Nome = "Unidade 1", Abrebiacao = "U1" }
            };
            _repositoryMock.Setup(r => r.GetByFilterAsync(filter)).ReturnsAsync(entities);

            var result = await _service.InvokeGetEntitiesByFilterAsync(filter);

            Assert.Single(result);
            Assert.Equal("Unidade 1", ((List<Domain.Entities.UnidadeMedida>)result)[0].Nome);
            _repositoryMock.Verify(r => r.GetByFilterAsync(filter), Times.Once);
        }
    }

    // Métodos auxiliares para acessar membros protegidos via reflexão
    public static class UnidadeMedidaServiceTestExtensions
    {
        public static Domain.Entities.UnidadeMedida InvokeConvertToEntity(this UnidadeMedidaService service, UnidadeMedida model)
            => (Domain.Entities.UnidadeMedida)typeof(UnidadeMedidaService)
                .GetMethod("ConvertToEntity", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .Invoke(service, new object[] { model });

        public static UnidadeMedida InvokeConvertToModel(this UnidadeMedidaService service, Domain.Entities.UnidadeMedida entity)
            => (UnidadeMedida)typeof(UnidadeMedidaService)
                .GetMethod("ConvertToModel", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .Invoke(service, new object[] { entity });

        public static void InvokeUpdateEntityFromModel(this UnidadeMedidaService service, Domain.Entities.UnidadeMedida entity, UnidadeMedida model)
            => typeof(UnidadeMedidaService)
                .GetMethod("UpdateEntityFromModel", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .Invoke(service, new object[] { entity, model });

        public static Task<IEnumerable<Domain.Entities.UnidadeMedida>> InvokeGetEntitiesByFilterAsync(this UnidadeMedidaService service, NomeFilter filter)
            => (Task<IEnumerable<Domain.Entities.UnidadeMedida>>)typeof(UnidadeMedidaService)
                .GetMethod("GetEntitiesByFilterAsync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .Invoke(service, new object[] { filter });
    }
}