using Moq;
using Precificador.Application.Model;
using Precificador.Application.Services;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository;

namespace Precificador.Tests.Application.Services
{
    public class ProdutoServiceTests
    {
        private readonly Mock<IProdutoRepository> _repositoryMock;
        private readonly ProdutoService _service;

        public ProdutoServiceTests()
        {
            _repositoryMock = new Mock<IProdutoRepository>();
            _service = new ProdutoService(_repositoryMock.Object);
        }

        [Fact]
        public void ConvertToEntity_DeveConverterModelParaEntity()
        {
            var model = new Produto
            {
                Id = Guid.NewGuid(),
                Nome = "Produto Teste",
                ColecaoId = Guid.NewGuid(),
                Margem = 0.25m,
                DataCalculoPreco = new DateTime(2024, 6, 1),
                PrecoCusto = 100m
            };

            var entity = _service.InvokeConvertToEntity(model);

            Assert.Equal(model.Id, entity.Id);
            Assert.Equal(model.Nome, entity.Nome);
            Assert.Equal(model.ColecaoId, entity.ColecaoId);
            Assert.Equal(model.Margem, entity.Margem);
            Assert.Equal(model.DataCalculoPreco, entity.DataCalculoPreco);
            Assert.Equal(model.PrecoCusto, entity.PrecoCusto);
        }

        [Fact]
        public void ConvertToModel_DeveConverterEntityParaModel()
        {
            var entity = new Domain.Entities.Produto
            {
                Id = Guid.NewGuid(),
                Nome = "Produto Entity",
                ColecaoId = Guid.NewGuid(),
                Margem = 0.30m,
                DataCalculoPreco = new DateTime(2024, 5, 10),
                PrecoCusto = 200m
            };

            var model = _service.InvokeConvertToModel(entity);

            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Nome, model.Nome);
            Assert.Equal(entity.ColecaoId, model.ColecaoId);
            Assert.Equal(entity.Margem, model.Margem);
            Assert.Equal(entity.DataCalculoPreco, model.DataCalculoPreco);
            Assert.Equal(entity.PrecoCusto, model.PrecoCusto);
            Assert.Equal(entity.PrecoFinal, model.PrecoFinal);
            Assert.Equal(entity.PrecoCustoX3, model.PrecoCustoX3);
            Assert.Equal(entity.PrecoCustoX35, model.PrecoCustoX35);
            Assert.Equal(entity.PrecoCustoX4, model.PrecoCustoX4);
        }

        [Fact]
        public void UpdateEntityFromModel_DeveAtualizarEntityComDadosDoModel()
        {
            var entity = new Domain.Entities.Produto
            {
                Id = Guid.NewGuid(),
                Nome = "Antigo",
                ColecaoId = Guid.NewGuid(),
                Margem = 0.10m,
                DataCalculoPreco = new DateTime(2020, 1, 1),
                PrecoCusto = 50m
            };
            var model = new Produto
            {
                Nome = "Novo",
                ColecaoId = Guid.NewGuid(),
                Margem = 0.50m,
                DataCalculoPreco = new DateTime(2025, 2, 2),
                PrecoCusto = 300m
            };

            _service.InvokeUpdateEntityFromModel(entity, model);

            Assert.Equal(model.Nome, entity.Nome);
            Assert.Equal(model.ColecaoId, entity.ColecaoId);
            Assert.Equal(model.Margem, entity.Margem);
            Assert.Equal(model.DataCalculoPreco, entity.DataCalculoPreco);
            Assert.Equal(model.PrecoCusto, entity.PrecoCusto);
        }

        [Fact]
        public async Task GetEntitiesByFilterAsync_DeveChamarRepositorioComFiltro()
        {
            var filter = new NomeFilter { Nome = "Filtro" };
            var entities = new List<Domain.Entities.Produto>
            {
                new Domain.Entities.Produto { Id = Guid.NewGuid(), Nome = "Produto 1" }
            };
            _repositoryMock.Setup(r => r.GetByFilterAsync(filter)).ReturnsAsync(entities);

            var result = await _service.InvokeGetEntitiesByFilterAsync(filter);

            Assert.Single(result);
            Assert.Equal("Produto 1", ((List<Domain.Entities.Produto>)result)[0].Nome);
            _repositoryMock.Verify(r => r.GetByFilterAsync(filter), Times.Once);
        }
    }

    // Métodos auxiliares para acessar membros protegidos via reflexão
    public static class ProdutoServiceTestExtensions
    {
        public static Domain.Entities.Produto InvokeConvertToEntity(this ProdutoService service, Produto model)
            => (Domain.Entities.Produto)typeof(ProdutoService)
                .GetMethod("ConvertToEntity", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .Invoke(service, new object[] { model });

        public static Produto InvokeConvertToModel(this ProdutoService service, Domain.Entities.Produto entity)
            => (Produto)typeof(ProdutoService)
                .GetMethod("ConvertToModel", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .Invoke(service, new object[] { entity });

        public static void InvokeUpdateEntityFromModel(this ProdutoService service, Domain.Entities.Produto entity, Produto model)
            => typeof(ProdutoService)
                .GetMethod("UpdateEntityFromModel", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .Invoke(service, new object[] { entity, model });

        public static Task<IEnumerable<Domain.Entities.Produto>> InvokeGetEntitiesByFilterAsync(this ProdutoService service, NomeFilter filter)
            => (Task<IEnumerable<Domain.Entities.Produto>>)typeof(ProdutoService)
                .GetMethod("GetEntitiesByFilterAsync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .Invoke(service, new object[] { filter });
    }
}