using Microsoft.EntityFrameworkCore.Migrations;

namespace SiGEv.Migrations
{
    public partial class protocol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Protocol",
                table: "Bills",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "DocumentType",
                table: "Bills",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentType",
                table: "Bills");

            migrationBuilder.AlterColumn<int>(
                name: "Protocol",
                table: "Bills",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
