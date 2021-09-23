using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    qst_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    qst_tag = table.Column<string>(type: "varchar(10)", nullable: true),
                    qst_cont = table.Column<string>(type: "varchar(500)", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<string>(type: "varchar(20)", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    isPublished = table.Column<string>(type: "char(1)", nullable: false),
                    isActive = table.Column<string>(type: "char(1)", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.qst_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
