using Microsoft.EntityFrameworkCore.Migrations;

namespace ProAgil_WebApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Eventoid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Local = table.Column<string>(type: "TEXT", nullable: true),
                    DataEvento = table.Column<string>(type: "TEXT", nullable: true),
                    Tema = table.Column<string>(type: "TEXT", nullable: true),
                    QntdPessoas = table.Column<int>(type: "INTEGER", nullable: false),
                    Lote = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Eventoid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
