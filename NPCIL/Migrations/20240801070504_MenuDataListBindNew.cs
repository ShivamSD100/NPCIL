using Microsoft.EntityFrameworkCore.Migrations;

namespace NPCIL.Migrations
{
    public partial class MenuDataListBindNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Controller",
                table: "tbl_AddMenu");

            migrationBuilder.AddColumn<string>(
                name: "DataListBind",
                table: "tbl_AddMenu",
                unicode: false,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataListBind",
                table: "tbl_AddMenu");

            migrationBuilder.AddColumn<string>(
                name: "Controller",
                table: "tbl_AddMenu",
                type: "varchar(max)",
                unicode: false,
                nullable: true);
        }
    }
}
