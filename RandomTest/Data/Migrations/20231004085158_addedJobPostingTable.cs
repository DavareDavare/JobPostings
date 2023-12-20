using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RandomTest.Data.Migrations
{
    public partial class addedJobPostingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobPosts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<float>(type: "real", nullable: false),
                    Startdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Companyname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPosts", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobPosts");
        }
    }
}
