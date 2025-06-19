using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Precificador.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Relacionamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MateriasPrimas_Grupos_GrupoId",
                table: "MateriasPrimas");

            migrationBuilder.DropForeignKey(
                name: "FK_MateriasPrimas_UnidadeMedida_UnidadeMedidaId",
                table: "MateriasPrimas");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Colecoes_ColecaoId",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnidadeMedida",
                table: "UnidadeMedida");

            migrationBuilder.RenameTable(
                name: "UnidadeMedida",
                newName: "UnidadesMedida");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Produtos",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Local",
                table: "PesquisasPrecos",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "MateriasPrimas",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Grupos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Colecoes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "UnidadesMedida",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Abrebiacao",
                table: "UnidadesMedida",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnidadesMedida",
                table: "UnidadesMedida",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MateriasPrimas_Grupos_GrupoId",
                table: "MateriasPrimas",
                column: "GrupoId",
                principalTable: "Grupos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MateriasPrimas_UnidadesMedida_UnidadeMedidaId",
                table: "MateriasPrimas",
                column: "UnidadeMedidaId",
                principalTable: "UnidadesMedida",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Colecoes_ColecaoId",
                table: "Produtos",
                column: "ColecaoId",
                principalTable: "Colecoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MateriasPrimas_Grupos_GrupoId",
                table: "MateriasPrimas");

            migrationBuilder.DropForeignKey(
                name: "FK_MateriasPrimas_UnidadesMedida_UnidadeMedidaId",
                table: "MateriasPrimas");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Colecoes_ColecaoId",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnidadesMedida",
                table: "UnidadesMedida");

            migrationBuilder.RenameTable(
                name: "UnidadesMedida",
                newName: "UnidadeMedida");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Local",
                table: "PesquisasPrecos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "MateriasPrimas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Grupos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Colecoes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "UnidadeMedida",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Abrebiacao",
                table: "UnidadeMedida",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnidadeMedida",
                table: "UnidadeMedida",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MateriasPrimas_Grupos_GrupoId",
                table: "MateriasPrimas",
                column: "GrupoId",
                principalTable: "Grupos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MateriasPrimas_UnidadeMedida_UnidadeMedidaId",
                table: "MateriasPrimas",
                column: "UnidadeMedidaId",
                principalTable: "UnidadeMedida",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Colecoes_ColecaoId",
                table: "Produtos",
                column: "ColecaoId",
                principalTable: "Colecoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
