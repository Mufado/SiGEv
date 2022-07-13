using Microsoft.EntityFrameworkCore.Migrations;

namespace SiGEv.Migrations
{
    public partial class EventToBill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Bills",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_EventId",
                table: "Bills",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Events_EventId",
                table: "Bills",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Events_EventId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_EventId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Bills");
        }
    }
}
