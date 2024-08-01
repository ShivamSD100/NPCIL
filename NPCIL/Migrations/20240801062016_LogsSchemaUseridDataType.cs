using Microsoft.EntityFrameworkCore.Migrations;

namespace NPCIL.Migrations
{
    public partial class LogsSchemaUseridDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
        name: "UserId",
        table: "Logs",
        type: "nvarchar(50)", 
        nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
        name: "UserId",
        table: "Logs",
        type: "nvarchar(20)", 
        nullable: true);
        }
    }
}
