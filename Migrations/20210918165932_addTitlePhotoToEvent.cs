using Microsoft.EntityFrameworkCore.Migrations;

namespace Events.Migrations
{
    public partial class addTitlePhotoToEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TitlePhoto",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TitlePhoto",
                table: "Events");
        }
    }
}
