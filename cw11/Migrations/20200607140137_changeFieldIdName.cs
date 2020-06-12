using Microsoft.EntityFrameworkCore.Migrations;

namespace cw11.Migrations
{
    public partial class changeFieldIdName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Doctors");

            migrationBuilder.AddColumn<int>(
                name: "IdDoctor",
                table: "Doctors",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors",
                column: "IdDoctor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "IdDoctor",
                table: "Doctors");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors",
                column: "Id");
        }
    }
}
