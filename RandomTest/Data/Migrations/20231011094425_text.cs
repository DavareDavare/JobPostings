using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RandomTest.Data.Migrations
{
    public partial class text : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "JobPosts",
                newName: "JobDescription");

            migrationBuilder.AlterColumn<string>(
                name: "Companyname",
                table: "JobPosts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JobDescription",
                table: "JobPosts",
                newName: "Description");

            migrationBuilder.AlterColumn<string>(
                name: "Companyname",
                table: "JobPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
