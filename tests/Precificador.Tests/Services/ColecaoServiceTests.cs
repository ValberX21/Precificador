using Moq;
using Precificador.Application.Model;
using Precificador.Application.Services;
using Precificador.Domain.Repository;

namespace Precificador.Tests.Services
{
    public class ColecaoServiceTests
    {
        private readonly Mock<IColecaoRepository> _repoMock;
        private readonly ColecaoService _service;

        public ColecaoServiceTests()
        {
            _repoMock = new Mock<IColecaoRepository>();
            _service = new ColecaoService(_repoMock.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldCallRepository_AndReturnTrue()
        {
            var model = new Colecao { Id = Guid.NewGuid(), Nome = "Teste" };
            _repoMock.Setup(r => r.AddAsync(It.IsAny<Precificador.Domain.Entities.Colecao>())).ReturnsAsync(true);

            var result = await _service.AddAsync(model);

            Assert.True(result);
            _repoMock.Verify(r => r.AddAsync(It.IsAny<Domain.Entities.Colecao>()), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnFalse_WhenNotFound()
        {
            _repoMock.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Domain.Entities.Colecao)null);

            var result = await _service.DeleteAsync(Guid.NewGuid());

            Assert.False(result);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnTrue_WhenFound()
        {
            var entity = new Domain.Entities.Colecao { Id = Guid.NewGuid(), Nome = "Teste Automatizado", Ativo = true };
            _repoMock.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(entity);
            _repoMock.Setup(r => r.UpdateAsync(entity)).ReturnsAsync(true);

            var result = await _service.DeleteAsync(entity.Id);

            Assert.True(result);
            Assert.False(entity.Ativo);
            _repoMock.Verify(r => r.UpdateAsync(entity), Times.Once);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnModels()
        {
            _repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(
                new List<Domain.Entities.Colecao>
                {
                    new Domain.Entities.Colecao { Id = Guid.NewGuid(), Nome = "X" }
                });

            var result = await _service.GetAllAsync();

            Assert.Single(result);
            Assert.Equal("X", result.First().Nome); // Use First() instead of indexing
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnNull_WhenRepositoryReturnsNull()
        {
            _repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync((IEnumerable<Domain.Entities.Colecao>)null);

            var result = await _service.GetAllAsync();

            Assert.Null(result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnModel_WhenFound()
        {
            var entity = new Domain.Entities.Colecao { Id = Guid.NewGuid(), Nome = "Y" };
            _repoMock.Setup(r => r.GetByIdAsync(entity.Id)).ReturnsAsync(entity);

            var result = await _service.GetByIdAsync(entity.Id);

            Assert.NotNull(result);
            Assert.Equal("Y", result.Nome);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull_WhenNotFound()
        {
            _repoMock.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Domain.Entities.Colecao)null);

            var result = await _service.GetByIdAsync(Guid.NewGuid());

            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnFalse_WhenNotFound()
        {
            _repoMock.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Domain.Entities.Colecao)null);

            var result = await _service.UpdateAsync(new Colecao { Id = Guid.NewGuid(), Nome = "Z" });

            Assert.False(result);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnTrue_WhenFound()
        {
            var entity = new Domain.Entities.Colecao { Id = Guid.NewGuid(), Nome = "Old" };
            _repoMock.Setup(r => r.GetByIdAsync(entity.Id)).ReturnsAsync(entity);
            _repoMock.Setup(r => r.UpdateAsync(entity)).ReturnsAsync(true);

            var value = new Colecao { Id = entity.Id, Nome = "New" };

            var result = await _service.UpdateAsync(value);

            Assert.True(result);
            Assert.Equal("New", entity.Nome);
            _repoMock.Verify(r => r.UpdateAsync(entity), Times.Once);
        }
    }
}