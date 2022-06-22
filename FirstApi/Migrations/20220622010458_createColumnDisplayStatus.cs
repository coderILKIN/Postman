using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstApi.Migrations
{
    public partial class createColumnDisplayStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DisplayStatis",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayStatis",
                table: "Products");
        }
    }
}
