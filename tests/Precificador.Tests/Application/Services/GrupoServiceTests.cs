using Moq;
using Precificador.Application.Model;
using Precificador.Application.Services;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository;

namespace Precificador.Tests.Application.Services
{
    public class GrupoServiceTests
    {
        private readonly Mock<IGrupoRepository> _repositoryMock;
        private readonly GrupoService _service;

        public GrupoServiceTests()
        {
            _repositoryMock = new Mock<IGrupoRepository>();
            _service = new GrupoService(_repositoryMock.Object);
        }

        [Fact]
        public void ConvertToEntity_DeveConverterModelParaEntity()
        {
            var model = new Grupo
            {
                Id = Guid.NewGuid(),
                Nome = "Grupo Teste"
            };

            var entity = _service.InvokeConvertToEntity(model);

            Assert.Equal(model.Id, entity.Id);
            Assert.Equal(model.Nome, entity.Nome);
        }

        [Fact]
        public void ConvertToModel_DeveConverterEntityParaModel()
        {
            var entity = new Domain.Entities.Grupo
            {
                Id = Guid.NewGuid(),
                Nome = "Grupo Entity"
            };

            var model = _service.InvokeConvertToModel(entity);

            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Nome, model.Nome);
        }

        [Fact]
        public void UpdateEntityFromModel_DeveAtualizarEntityComDadosDoModel()
        {
            var entity = new Domain.Entities.Grupo
            {
                Id = Guid.NewGuid(),
                Nome = "Antigo"
            };
            var model = new Grupo
            {
                Nome = "Novo"
            };

            _service.InvokeUpdateEntityFromModel(entity, model);

            Assert.Equal(model.Nome, entity.Nome);
        }

        [Fact]
        public async Task GetEntitiesByFilterAsync_DeveChamarRepositorioComFiltro()
        {
            var filter = new NomeFilter { Nome = "Filtro" };
            var entities = new List<Domain.Entities.Grupo>
            {
                new Domain.Entities.Grupo { Id = Guid.NewGuid(), Nome = "Grupo 1" }
            };
            _repositoryMock.Setup(r => r.GetByFilterAsync(filter)).ReturnsAsync(entities);

            var result = await _service.InvokeGetEntitiesByFilterAsync(filter);

            Assert.Single(result);
            Assert.Equal("Grupo 1", ((List<Domain.Entities.Grupo>)result)[0].Nome);
            _repositoryMock.Verify(r => r.GetByFilterAsync(filter), Times.Once);
        }
    }

    // Métodos auxiliares para acessar membros protegidos via reflexão
    public static class GrupoServiceTestExtensions
    {
        public static Domain.Entities.Grupo InvokeConvertToEntity(this GrupoService service, Grupo model)
            => (Domain.Entities.Grupo)typeof(GrupoService)
                .GetMethod("ConvertToEntity", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .Invoke(service, new object[] { model });

        public static Grupo InvokeConvertToModel(this GrupoService service, Domain.Entities.Grupo entity)
            => (Grupo)typeof(GrupoService)
                .GetMethod("ConvertToModel", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .Invoke(service, new object[] { entity });

        public static void InvokeUpdateEntityFromModel(this GrupoService service, Domain.Entities.Grupo entity, Grupo model)
            => typeof(GrupoService)
                .GetMethod("UpdateEntityFromModel", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .Invoke(service, new object[] { entity, model });

        public static Task<IEnumerable<Domain.Entities.Grupo>> InvokeGetEntitiesByFilterAsync(this GrupoService service, NomeFilter filter)
            => (Task<IEnumerable<Domain.Entities.Grupo>>)typeof(GrupoService)
                .GetMethod("GetEntitiesByFilterAsync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .Invoke(service, new object[] { filter });
    }
}