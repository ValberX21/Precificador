using Moq;
using Precificador.Application.Model;
using Precificador.Application.Services;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository;

namespace Precificador.Tests.Application.Services
{
    public class PesquisaPrecoServiceTests
    {
        private readonly Mock<IPesquisaPrecoRepository> _repositoryMock;
        private readonly PesquisaPrecoService _service;

        public PesquisaPrecoServiceTests()
        {
            _repositoryMock = new Mock<IPesquisaPrecoRepository>();
            _service = new PesquisaPrecoService(_repositoryMock.Object);
        }

        [Fact]
        public void ConvertToEntity_DeveConverterModelParaEntity()
        {
            var model = new PesquisaPreco
            {
                Id = Guid.NewGuid(),
                ProdutoId = Guid.NewGuid(),
                Local = "Supermercado X",
                Valor = 15.5m,
                DataPesquisa = new DateTime(2024, 6, 1)
            };

            var entity = _service.InvokeConvertToEntity(model);

            Assert.Equal(model.Id, entity.Id);
            Assert.Equal(model.ProdutoId, entity.ProdutoId);
            Assert.Equal(model.Local, entity.Local);
            Assert.Equal(model.Valor, entity.Valor);
            Assert.Equal(model.DataPesquisa, entity.DataPesquisa);
        }

        [Fact]
        public void ConvertToModel_DeveConverterEntityParaModel()
        {
            var entity = new Domain.Entities.PesquisaPreco
            {
                Id = Guid.NewGuid(),
                ProdutoId = Guid.NewGuid(),
                Local = "Mercado Y",
                Valor = 20.0m,
                DataPesquisa = new DateTime(2024, 5, 10)
            };

            var model = _service.InvokeConvertToModel(entity);

            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.ProdutoId, model.ProdutoId);
            Assert.Equal(entity.Local, model.Local);
            Assert.Equal(entity.Valor, model.Valor);
            Assert.Equal(entity.DataPesquisa, model.DataPesquisa);
        }

        [Fact]
        public void UpdateEntityFromModel_DeveAtualizarEntityComDadosDoModel()
        {
            var entity = new Domain.Entities.PesquisaPreco
            {
                Id = Guid.NewGuid(),
                ProdutoId = Guid.NewGuid(),
                Local = "Antigo",
                Valor = 10.0m,
                DataPesquisa = new DateTime(2024, 1, 1)
            };
            var model = new PesquisaPreco
            {
                ProdutoId = Guid.NewGuid(),
                Local = "Novo Local",
                Valor = 99.9m,
                DataPesquisa = new DateTime(2024, 6, 10)
            };

            _service.InvokeUpdateEntityFromModel(entity, model);

            Assert.Equal(model.ProdutoId, entity.ProdutoId);
            Assert.Equal(model.Local, entity.Local);
            Assert.Equal(model.Valor, entity.Valor);
            Assert.Equal(model.DataPesquisa, entity.DataPesquisa);
        }

        [Fact]
        public async Task GetEntitiesByFilterAsync_DeveChamarRepositorioComFiltro()
        {
            var filter = new PesquisaPrecoFilter { ProdutoNome = "Arroz", Local = "Mercado" };
            var entities = new List<Domain.Entities.PesquisaPreco>
            {
                new Domain.Entities.PesquisaPreco { Id = Guid.NewGuid(), Local = "Mercado" }
            };
            _repositoryMock.Setup(r => r.GetByFilterAsync(filter)).ReturnsAsync(entities);

            var result = await _service.InvokeGetEntitiesByFilterAsync(filter);

            Assert.Single(result);
            Assert.Equal("Mercado", ((List<Domain.Entities.PesquisaPreco>)result)[0].Local);
            _repositoryMock.Verify(r => r.GetByFilterAsync(filter), Times.Once);
        }
    }

    // Métodos auxiliares para acessar membros protegidos via reflexão
    public static class PesquisaPrecoServiceTestExtensions
    {
        public static Domain.Entities.PesquisaPreco InvokeConvertToEntity(this PesquisaPrecoService service, PesquisaPreco model)
            => (Domain.Entities.PesquisaPreco)typeof(PesquisaPrecoService)
                .GetMethod("ConvertToEntity", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .Invoke(service, new object[] { model });

        public static PesquisaPreco InvokeConvertToModel(this PesquisaPrecoService service, Domain.Entities.PesquisaPreco entity)
            => (PesquisaPreco)typeof(PesquisaPrecoService)
                .GetMethod("ConvertToModel", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .Invoke(service, new object[] { entity });

        public static void InvokeUpdateEntityFromModel(this PesquisaPrecoService service, Domain.Entities.PesquisaPreco entity, PesquisaPreco model)
            => typeof(PesquisaPrecoService)
                .GetMethod("UpdateEntityFromModel", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .Invoke(service, new object[] { entity, model });

        public static Task<IEnumerable<Domain.Entities.PesquisaPreco>> InvokeGetEntitiesByFilterAsync(this PesquisaPrecoService service, PesquisaPrecoFilter filter)
            => (Task<IEnumerable<Domain.Entities.PesquisaPreco>>)typeof(PesquisaPrecoService)
                .GetMethod("GetEntitiesByFilterAsync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .Invoke(service, new object[] { filter });
    }
}