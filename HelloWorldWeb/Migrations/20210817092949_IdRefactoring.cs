using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloWorldWeb.Migrations
{
    public partial class IdRefactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "TeamMembers",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TeamMembers",
                newName: "ID");
        }
    }
}
