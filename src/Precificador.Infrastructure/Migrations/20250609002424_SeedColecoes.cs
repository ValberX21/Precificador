using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Precificador.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedColecoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO [dbo].[Colecoes] ([Id], [Ano], [DataLancamento], [Nome], [DataCriacao], [DataAlteracao], [Ativo]) VALUES
                (NEWID(), 2024, NULL, 'Dininha', GETDATE(), NULL, 1),
                (NEWID(), 2023, NULL, 'Kraft', GETDATE(), NULL, 1),
                (NEWID(), 2024, NULL, 'Couro', GETDATE(), NULL, 1),
                (NEWID(), 2018, NULL, 'Crochê', GETDATE(), NULL, 1),
                (NEWID(), 2019, NULL, 'Bebê', GETDATE(), NULL, 1),
                (NEWID(), 2019, NULL, 'Casamento', GETDATE(), NULL, 1),
                (NEWID(), 2020, NULL, 'Trevo Saúde', GETDATE(), NULL, 1),
                (NEWID(), 2022, NULL, 'Fofurinhas', GETDATE(), NULL, 1),
                (NEWID(), 2020, NULL, 'Costura Criativa', GETDATE(), NULL, 1),
                (NEWID(), 2022, NULL, 'Sacolas em Papel', GETDATE(), NULL, 1),
                (NEWID(), 2022, NULL, 'Sacolas 60', GETDATE(), NULL, 1),
                (NEWID(), 2022, NULL, 'Sacolas 40', GETDATE(), NULL, 1),
                (NEWID(), 2022, NULL, 'Natal 2022', GETDATE(), NULL, 1),
                (NEWID(), 2023, NULL, 'Coleção 2023', GETDATE(), NULL, 1),
                (NEWID(), 2023, NULL, 'Volta às Aulas 2023', GETDATE(), NULL, 1),
                (NEWID(), 2023, NULL, 'Mulher 2023', GETDATE(), NULL, 1),
                (NEWID(), 2023, NULL, 'Páscoa 2023', GETDATE(), NULL, 1),
                (NEWID(), 2023, NULL, 'Mães 2023', GETDATE(), NULL, 1),
                (NEWID(), 2023, NULL, 'Namorados 2023', GETDATE(), NULL, 1),
                (NEWID(), 2023, NULL, 'Pais 2023', GETDATE(), NULL, 1),
                (NEWID(), 2024, NULL, 'Coleção 2024', GETDATE(), NULL, 1),
                (NEWID(), 2024, NULL, 'Volta às Aulas 2024', GETDATE(), NULL, 1),
                (NEWID(), 2024, NULL, 'Mulher 2024', GETDATE(), NULL, 1),
                (NEWID(), 2024, NULL, 'Páscoa 2024', GETDATE(), NULL, 1),
                (NEWID(), 2024, NULL, 'Mães 2024', GETDATE(), NULL, 1),
                (NEWID(), 2024, NULL, 'Arraiá 2024', GETDATE(), NULL, 1),
                (NEWID(), 2025, NULL, 'Coleção 2025', GETDATE(), NULL, 1),
                (NEWID(), 2025, NULL, 'Volta às Aulas 2025', GETDATE(), NULL, 1),
                (NEWID(), 2025, NULL, 'Mulher 2025', GETDATE(), NULL, 1)"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM [dbo].[Colecoes] WHERE [Nome] IN (
                'Dininha','Kraft','Couro','Crochê','Bebê','Casamento','Trevo Saúde','Fofurinhas',
                'Costura Criativa','Sacolas em Papel','Sacolas 60','Sacolas 40','Natal 2022','Coleção 2023',
                'Volta às Aulas 2023','Mulher 2023','Páscoa 2023','Mães 2023','Namorados 2023','Pais 2023',
                'Coleção 2024','Volta às Aulas 2024','Mulher 2024','Páscoa 2024','Mães 2024','Arraiá 2024',
                'Coleção 2025','Volta às Aulas 2025','Mulher 2025')");
        }
    }
}
