using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Education.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EducationInitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.CursoId);
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "Descripcion", "FechaCreacion", "FechaPublicacion", "Precio", "Titulo" },
                values: new object[,]
                {
                    { new Guid("6f8c0f8a-4f8e-4f6a-9e4a-5d7a9c8b1f01"), "Aprende los fundamentos de java y desarrollo de aplicaciones.", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 57m, "Curso de Java" },
                    { new Guid("a3d2b9e7-7c41-4d9b-8a55-2e91f6c4d702"), "Aprende los fundamentos de C# y desarrollo de aplicaciones.", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 56m, "Curso de C#" },
                    { new Guid("d9f4a1c3-5e28-4b7d-91f2-8c6e3a7b5903"), "Aprende los fundamentos de Python y desarrollo de aplicaciones.", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 58m, "Curso de Python" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
