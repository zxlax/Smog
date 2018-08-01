using Microsoft.EntityFrameworkCore.Migrations;

namespace SmogInfo.Migrations
{
    public partial class Add25Con : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PM25Concentration",
                table: "SmogLevels",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PM25Concentration",
                table: "SmogLevels");
        }
    }
}
