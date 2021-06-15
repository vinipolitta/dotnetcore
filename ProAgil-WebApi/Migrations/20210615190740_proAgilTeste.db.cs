using Microsoft.EntityFrameworkCore.Migrations;

namespace ProAgil_WebApi.Migrations
{
    public partial class proAgilTestedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imageUrl",
                table: "Eventos",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageUrl",
                table: "Eventos");
        }
    }
}
