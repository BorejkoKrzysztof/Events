using Microsoft.EntityFrameworkCore.Migrations;


namespace Events.Migrations
{
    public partial class FixONE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Accounts_AccountId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AccountId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "AccountOwnerId",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccountOwnerId1",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountOwnerId1",
                table: "Accounts",
                column: "AccountOwnerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Users_AccountOwnerId1",
                table: "Accounts",
                column: "AccountOwnerId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Users_AccountOwnerId1",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_AccountOwnerId1",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountOwnerId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountOwnerId1",
                table: "Accounts");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AccountId",
                table: "Users",
                column: "AccountId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Accounts_AccountId",
                table: "Users",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
