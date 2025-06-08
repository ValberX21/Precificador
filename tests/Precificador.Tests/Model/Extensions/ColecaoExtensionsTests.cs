using Precificador.Application.Model;
using Precificador.Application.Model.Extensions;

namespace Precificador.Tests.Model.Extensions
{
    public class ColecaoExtensionsTests
    {
        [Fact]
        public void ConvertToEntity_ShouldMapFields()
        {
            var colecao = new Colecao { Id = Guid.NewGuid(), Nome = "Teste" };
            var entity = colecao.ConvertToEntity();
            Assert.Equal(colecao.Id, entity.Id);
            Assert.Equal(colecao.Nome, entity.Nome);
        }

        [Fact]
        public void ConvertToEntity_ShouldThrowArgumentNullException_WhenNull()
        {
            Colecao colecao = null;
            var ex = Assert.Throws<ArgumentNullException>(() => colecao.ConvertToEntity());
            Assert.Equal("colecao", ex.ParamName);
        }

        [Fact]
        public void ConvertToModel_EntityToModel_ShouldMapFields()
        {
            var entity = new Precificador.Domain.Entities.Colecao { Id = Guid.NewGuid(), Nome = "Teste" };
            var model = entity.ConvertToModel();
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Nome, model.Nome);
        }

        [Fact]
        public void ConvertToModel_EntityToModel_ShouldThrowArgumentNullException_WhenNull()
        {
            Precificador.Domain.Entities.Colecao entity = null;
            var ex = Assert.Throws<ArgumentNullException>(() => entity.ConvertToModel());
            Assert.Equal("colecao", ex.ParamName);
        }

        [Fact]
        public void ConvertToModel_Collection_ShouldMapAll()
        {
            var entities = new List<Precificador.Domain.Entities.Colecao>
        {
            new Precificador.Domain.Entities.Colecao { Id = Guid.NewGuid(), Nome = "A" },
            new Precificador.Domain.Entities.Colecao { Id = Guid.NewGuid(), Nome = "B" }
        };
            var models = entities.ConvertToModel();
            Assert.Equal(2, models.Count);
            Assert.Equal(entities[0].Nome, models[0].Nome);
            Assert.Equal(entities[1].Nome, models[1].Nome);
        }

        [Fact]
        public void ConvertToModel_Collection_ShouldThrowArgumentNullException_WhenNull()
        {
            IEnumerable<Precificador.Domain.Entities.Colecao> entities = null;
            var ex = Assert.Throws<ArgumentNullException>(() => entities.ConvertToModel());
            Assert.Equal("colecoes", ex.ParamName);
        }
    }
}