using Microsoft.EntityFrameworkCore.Migrations;

namespace MOCProject.Data.Migrations
{
    public partial class departmentMocs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Mocs_MocId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_MocId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "MocId",
                table: "Departments");

            migrationBuilder.CreateTable(
                name: "DepartmentMoc",
                columns: table => new
                {
                    MocsId = table.Column<int>(type: "int", nullable: false),
                    RelatedDepartmentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentMoc", x => new { x.MocsId, x.RelatedDepartmentsId });
                    table.ForeignKey(
                        name: "FK_DepartmentMoc_Departments_RelatedDepartmentsId",
                        column: x => x.RelatedDepartmentsId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentMoc_Mocs_MocsId",
                        column: x => x.MocsId,
                        principalTable: "Mocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentMoc_RelatedDepartmentsId",
                table: "DepartmentMoc",
                column: "RelatedDepartmentsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentMoc");

            migrationBuilder.AddColumn<int>(
                name: "MocId",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_MocId",
                table: "Departments",
                column: "MocId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Mocs_MocId",
                table: "Departments",
                column: "MocId",
                principalTable: "Mocs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
