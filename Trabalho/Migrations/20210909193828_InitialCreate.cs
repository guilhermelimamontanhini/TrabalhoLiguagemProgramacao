using Microsoft.EntityFrameworkCore.Migrations;

namespace Trabalho.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuarioID = table.Column<int>(type: "int", nullable: false),
                    plataformaID = table.Column<int>(type: "int", nullable: false),
                    nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    preco = table.Column<double>(type: "float", nullable: false),
                    genero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    plataformaID = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Plataformas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Usuarioid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plataformas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Plataformas_Usuarios_Usuarioid",
                        column: x => x.Usuarioid,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_plataformaID",
                table: "Jogos",
                column: "plataformaID");

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_usuarioID",
                table: "Jogos",
                column: "usuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Plataformas_Usuarioid",
                table: "Plataformas",
                column: "Usuarioid");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_plataformaID",
                table: "Usuarios",
                column: "plataformaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Plataformas_plataformaID",
                table: "Jogos",
                column: "plataformaID",
                principalTable: "Plataformas",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Usuarios_usuarioID",
                table: "Jogos",
                column: "usuarioID",
                principalTable: "Usuarios",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Plataformas_plataformaID",
                table: "Usuarios",
                column: "plataformaID",
                principalTable: "Plataformas",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Plataformas_plataformaID",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Jogos");

            migrationBuilder.DropTable(
                name: "Plataformas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
