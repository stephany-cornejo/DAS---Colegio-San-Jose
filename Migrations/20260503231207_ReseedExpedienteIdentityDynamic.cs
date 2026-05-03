using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColegioSanJose.Migrations
{
    /// <inheritdoc />
    public partial class ReseedExpedienteIdentityDynamic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DECLARE @MaxId INT = (SELECT ISNULL(MAX(ExtpedienteId), 0) FROM Expediente); DBCC CHECKIDENT ('Expediente', RESEED, @MaxId);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
