using Microsoft.EntityFrameworkCore;
using Precificador.Domain.Entities;

namespace Precificador.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<MateriaPrima> MateriasPrimas { get; set; }
        public DbSet<Colecao> Colecoes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoMateriaPrima> ProdutoMateriaPrimas { get; set; }
        public DbSet<PesquisaPreco> PesquisasPrecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //
        }
    }
}
