using Microsoft.EntityFrameworkCore.Migrations;

namespace MOCProject.Data.Migrations
{
    public partial class ClosingNoteAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClosingNote",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClosingNote",
                table: "Tasks");
        }
    }
}
