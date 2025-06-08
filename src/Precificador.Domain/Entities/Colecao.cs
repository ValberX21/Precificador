using Precificador.Domain.Entities.Base;

namespace Precificador.Domain.Entities
{
    public class Colecao : BaseEntity
    {
        public int Ano { get; set; }
        public DateTime? DataLancamento { get; set; }
        public ICollection<Produto>? Produtos { get; set; }
    }
}