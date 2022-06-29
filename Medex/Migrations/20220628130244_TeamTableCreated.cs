using Microsoft.EntityFrameworkCore.Migrations;

namespace Medex.Migrations
{
    public partial class TeamTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(nullable: true),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    Desc = table.Column<string>(maxLength: 100, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Profession = table.Column<string>(maxLength: 50, nullable: true),
                    Icons = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
