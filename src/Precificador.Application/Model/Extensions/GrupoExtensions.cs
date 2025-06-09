namespace Precificador.Application.Model.Extensions
{
    public static class GrupoExtensions
    {
        public static Domain.Entities.Grupo ConvertToEntity(this Model.Grupo grupo)
        {
            return grupo == null ? throw new ArgumentNullException(nameof(grupo), "Grupo não pode ser nulo") : new Domain.Entities.Grupo
            {
                Id = grupo.Id,
                Nome = grupo.Nome
            };
        }

        public static Model.Grupo ConvertToModel(this Domain.Entities.Grupo grupo)
        {
            return grupo == null ? throw new ArgumentNullException(nameof(grupo), "grupo não pode ser nulo") : new Model.Grupo
            {
                Id = grupo.Id,
                Nome = grupo.Nome
            };
        }

        public static IList<Model.Grupo> ConvertToModel(this IEnumerable<Domain.Entities.Grupo> lista)
        {
            return lista == null ? throw new ArgumentNullException(nameof(lista), "Colecoes não pode ser nulo") : (IList<Grupo>)[.. lista.Select(c => c.ConvertToModel())];
        }
    }
}