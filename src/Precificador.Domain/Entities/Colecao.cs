using Precificador.Domain.Entities.Base;

namespace Precificador.Domain.Entities
{
    public class Colecao : BaseEntity
    {
        public ICollection<Produto>? Produtos { get; set; }
    }
}