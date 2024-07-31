using Microsoft.EntityFrameworkCore.Migrations;

namespace NPCIL.Migrations
{
    public partial class LogSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
               name: "LogDate",
               table: "Logs",
               newName: "LogTimeStamp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
               name: "LogTimeStamp",
               table: "Logs",
               newName: "LogDate");
        }
    }
}
