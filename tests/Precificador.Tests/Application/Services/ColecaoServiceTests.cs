using Moq;
using Precificador.Application.Model;
using Precificador.Application.Services;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository;

namespace Precificador.Tests.Application.Services
{
    public class ColecaoServiceTests
    {
        private readonly Mock<IColecaoRepository> _repositoryMock;
        private readonly ColecaoService _service;

        public ColecaoServiceTests()
        {
            _repositoryMock = new Mock<IColecaoRepository>();
            _service = new ColecaoService(_repositoryMock.Object);
        }

        [Fact]
        public void ConvertToEntity_DeveConverterModelParaEntity()
        {
            var model = new Colecao
            {
                Id = Guid.NewGuid(),
                Nome = "Coleção Teste",
                Ano = 2024,
                DataLancamento = new DateTime(2024, 1, 1)
            };

            var entity = _service.InvokeConvertToEntity(model);

            Assert.Equal(model.Id, entity.Id);
            Assert.Equal(model.Nome, entity.Nome);
            Assert.Equal(model.Ano, entity.Ano);
            Assert.Equal(model.DataLancamento, entity.DataLancamento);
        }

        [Fact]
        public void ConvertToModel_DeveConverterEntityParaModel()
        {
            var entity = new Domain.Entities.Colecao
            {
                Id = Guid.NewGuid(),
                Nome = "Coleção Entity",
                Ano = 2023,
                DataLancamento = new DateTime(2023, 5, 10)
            };

            var model = _service.InvokeConvertToModel(entity);

            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Nome, model.Nome);
            Assert.Equal(entity.Ano, model.Ano);
            Assert.Equal(entity.DataLancamento, model.DataLancamento);
        }

        [Fact]
        public void UpdateEntityFromModel_DeveAtualizarEntityComDadosDoModel()
        {
            var entity = new Domain.Entities.Colecao
            {
                Id = Guid.NewGuid(),
                Nome = "Antigo",
                Ano = 2020,
                DataLancamento = new DateTime(2020, 1, 1)
            };
            var model = new Colecao
            {
                Nome = "Novo",
                Ano = 2025,
                DataLancamento = new DateTime(2025, 2, 2)
            };

            _service.InvokeUpdateEntityFromModel(entity, model);

            Assert.Equal(model.Nome, entity.Nome);
            Assert.Equal(model.Ano, entity.Ano);
            Assert.Equal(model.DataLancamento, entity.DataLancamento);
        }

        [Fact]
        public async Task GetEntitiesByFilterAsync_DeveChamarRepositorioComFiltro()
        {
            var filter = new NomeFilter { Nome = "Filtro" };
            var entities = new List<Domain.Entities.Colecao>
            {
                new Domain.Entities.Colecao { Id = Guid.NewGuid(), Nome = "Coleção 1", Ano = 2022 }
            };
            _repositoryMock.Setup(r => r.GetByFilterAsync(filter)).ReturnsAsync(entities);

            var result = await _service.InvokeGetEntitiesByFilterAsync(filter);

            Assert.Single(result);
            Assert.Equal("Coleção 1", ((List<Domain.Entities.Colecao>)result)[0].Nome);
            _repositoryMock.Verify(r => r.GetByFilterAsync(filter), Times.Once);
        }
    }

    // Métodos auxiliares para acessar membros protegidos
    public static class ColecaoServiceTestExtensions
    {
        public static Domain.Entities.Colecao InvokeConvertToEntity(this ColecaoService service, Colecao model)
            => (Domain.Entities.Colecao)typeof(ColecaoService)
                .GetMethod("ConvertToEntity", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .Invoke(service, new object[] { model });

        public static Colecao InvokeConvertToModel(this ColecaoService service, Domain.Entities.Colecao entity)
            => (Colecao)typeof(ColecaoService)
                .GetMethod("ConvertToModel", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .Invoke(service, new object[] { entity });

        public static void InvokeUpdateEntityFromModel(this ColecaoService service, Domain.Entities.Colecao entity, Colecao model)
            => typeof(ColecaoService)
                .GetMethod("UpdateEntityFromModel", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .Invoke(service, new object[] { entity, model });

        public static Task<IEnumerable<Domain.Entities.Colecao>> InvokeGetEntitiesByFilterAsync(this ColecaoService service, NomeFilter filter)
            => (Task<IEnumerable<Domain.Entities.Colecao>>)typeof(ColecaoService)
                .GetMethod("GetEntitiesByFilterAsync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .Invoke(service, new object[] { filter });
    }
}
