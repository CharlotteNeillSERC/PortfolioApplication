using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioApplication.Data.Migrations
{
    public partial class initialContactSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    contactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contactSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contactMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactInfo");
        }
    }
}
