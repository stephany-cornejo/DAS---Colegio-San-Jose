using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColegioSanJose.Migrations
{
    /// <inheritdoc />
    public partial class ReseedMateriaIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DECLARE @MaxId INT = (SELECT ISNULL(MAX(MateriaId), 0) FROM Materia); DBCC CHECKIDENT ('Materia', RESEED, @MaxId);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
