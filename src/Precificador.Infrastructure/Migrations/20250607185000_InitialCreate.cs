using Microsoft.EntityFrameworkCore.Migrations;

namespace Precificador.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            #region Coleção

            migrationBuilder.CreateTable(
                name: "Colecao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Ano = table.Column<int>(nullable: false),
                    DataLancamento = table.Column<DateTime>(nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colecao", x => x.Id);
                });

            #endregion

            #region Grupo

            migrationBuilder.CreateTable(
                name: "Grupo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupo", x => x.Id);
                });

            #endregion

            #region Unidade de Medida

            migrationBuilder.CreateTable(
                name: "UnidadeMedida",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Abreviacao = table.Column<string>(maxLength: 4, nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadeMedida", x => x.Id);
                });

            #endregion

            #region Matéria-Prima

            migrationBuilder.CreateTable(
                name: "MateriaPrima",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    QtdPacote = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    VlrPacote = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    DataPreco = table.Column<DateTime>(nullable: false),
                    UnidadeMedidaId = table.Column<Guid>(nullable: false),
                    GrupoId = table.Column<Guid>(nullable: false),
                    VlrUnitario = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriaPrima", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatPrima_UnidadeMedida",
                        column: x => x.UnidadeMedidaId,
                        principalTable: "UnidadeMedida",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatPrima_Grupo",
                        column: x => x.GrupoId,
                        principalTable: "Grupo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            #endregion

            #region Produto

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    ColecaoId = table.Column<Guid>(nullable: false),
                    Margem = table.Column<decimal>(type: "decimal(5,4)", nullable: false, defaultValue: 0.55m),
                    DataCalculoPreco = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    PrecoCusto = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    PrecoFinal = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    PrecoCustoX3 = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    PrecoCustoX35 = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    PrecoCustoX4 = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Colecao",
                        column: x => x.ColecaoId,
                        principalTable: "Colecao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            #endregion

            #region PesquisaPreco

            migrationBuilder.CreateTable(
                name: "PesquisaPreco",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProdutoId = table.Column<Guid>(nullable: false),
                    Local = table.Column<string>(maxLength: 200, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    DataPesquisa = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PesquisaPreco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pesquisa_Produto",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            #endregion

            #region ProdutoMateriaPrima

            migrationBuilder.CreateTable(
                name: "ProdutoMateriaPrima",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProdutoId = table.Column<int>(nullable: false),
                    MateriaPrimaId = table.Column<int>(nullable: false),
                    Quantidade = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdMatPrima", x => new { x.Id });
                    table.ForeignKey(
                        name: "FK_PMP_Produto",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PMP_MatPrima",
                        column: x => x.MateriaPrimaId,
                        principalTable: "MateriaPrima",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            #endregion

            #region Índices

            migrationBuilder.CreateIndex(name: "IX_MatPrima_Grupo", table: "MateriaPrima", column: "GrupoId");
            migrationBuilder.CreateIndex(name: "IX_Produto_Colecao", table: "Produto", column: "ColecaoId");
            migrationBuilder.CreateIndex(name: "IX_PesquisaPreco_Produto", table: "PesquisaPreco", column: "ProdutoId");

            #endregion
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "PesquisaPreco");
            migrationBuilder.DropTable(name: "ProdutoMateriaPrima");
            migrationBuilder.DropTable(name: "Produto");
            migrationBuilder.DropTable(name: "MateriaPrima");
            migrationBuilder.DropTable(name: "Colecao");
            migrationBuilder.DropTable(name: "Grupo");
        }
    }
}