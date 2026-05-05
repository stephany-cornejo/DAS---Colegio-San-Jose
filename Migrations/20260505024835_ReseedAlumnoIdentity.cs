using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColegioSanJose.Migrations
{
    /// <inheritdoc />
    public partial class ReseedAlumnoIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DECLARE @MaxId INT = (SELECT ISNULL(MAX(AlumnoId), 0) FROM ALumno); DBCC CHECKIDENT ('ALumno', RESEED, @MaxId);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
