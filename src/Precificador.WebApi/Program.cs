using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Precificador.Application.Services;
using Precificador.Domain.Repository;
using Precificador.Infrastructure.Data;
using Precificador.Infrastructure.Repository;
using Serilog;

namespace Precificador.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Conexão com o banco de dados

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            #endregion

            #region Repositories

            builder.Services.AddScoped<IColecaoRepository, ColecaoRepository>();
            builder.Services.AddScoped<IGrupoRepository, GrupoRepository>();
            builder.Services.AddScoped<IMateriaPrimaRepository, MateriaPrimaRepository>();
            builder.Services.AddScoped<IPesquisaPrecoRepository, PesquisaPrecoRepository>();
            builder.Services.AddScoped<IProdutoMateriaPrimaRepository, ProdutoMateriaPrimaRepository>();
            builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
            builder.Services.AddScoped<IUnidadeMedidaRepository, UnidadeMedidaRepository>();

            #endregion

            #region Services

            builder.Services.AddScoped<IColecaoService, ColecaoService>();
            builder.Services.AddScoped<IGrupoService, GrupoService>();
            builder.Services.AddScoped<IMateriaPrimaService, MateriaPrimaService>();
            //builder.Services.AddScoped<IPesquisaPrecoService, PesquisaPrecoService>();
            //builder.Services.AddScoped<IProdutoMateriaPrimaService, ProdutoMateriaPrimaService>();
            builder.Services.AddScoped<IProdutoService, ProdutoService>();
            builder.Services.AddScoped<IUnidadeMedidaService, UnidadeMedidaService>();

            #endregion

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            #region Swagger

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Precificador WebAPI", Version = "v1" });
            });

            #endregion

            Log.Logger = new LoggerConfiguration().WriteTo.File("logs/app.log", rollingInterval: RollingInterval.Day).CreateLogger();
            
            builder.Services.AddLogging();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}