namespace Precificador.Application.Model.Extensions
{
    public static class ColecaoExtensions
    {
        public static Domain.Entities.Colecao ConvertToEntity(this Model.Colecao colecao)
        {
            return colecao == null ? throw new ArgumentNullException(nameof(colecao), "Colecao não pode ser nula") : new Domain.Entities.Colecao
            {
                Id = colecao.Id,
                Nome = colecao.Nome,
                Ano = colecao.Ano,
                DataLancamento = colecao.DataLancamento
            };
        }

        public static Model.Colecao ConvertToModel(this Domain.Entities.Colecao colecao)
        {
            return colecao == null ? throw new ArgumentNullException(nameof(colecao), "Colecao não pode ser nula") : new Model.Colecao
            {
                Id = colecao.Id,
                Nome = colecao.Nome,
                Ano = colecao.Ano,
                DataLancamento = colecao.DataLancamento
            };
        }

        public static IList<Model.Colecao> ConvertToModel(this IEnumerable<Domain.Entities.Colecao> colecoes)
        {
            return colecoes == null ? throw new ArgumentNullException(nameof(colecoes), "Colecoes não pode ser nulo") : (IList<Colecao>)colecoes.Select(c => c.ConvertToModel()).ToList();
        }
    }
}