using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebIdentity.Migrations
{
    /// <inheritdoc />
    public partial class princial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "DataCadastro", "Email", "Idade", "Nome" },
                values: new object[] { new Guid("099c21a1-0841-43af-a93a-e3cee7d4e2e7"), new DateTime(2024, 11, 13, 20, 7, 10, 706, DateTimeKind.Local).AddTicks(8017), "joaoguilhermemalves@gmail.com", 26, "Joao Guilherme" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
