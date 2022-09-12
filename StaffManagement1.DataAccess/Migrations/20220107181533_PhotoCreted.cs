using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StaffManagement1.DataAccess.Migrations
{
    public partial class PhotoCreted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoFilePath",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoFilePath",
                table: "Staffs");
        }
    }
}
