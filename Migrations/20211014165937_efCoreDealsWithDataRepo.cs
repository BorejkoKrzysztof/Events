using Microsoft.EntityFrameworkCore.Migrations;

namespace Events.Migrations
{
    public partial class efCoreDealsWithDataRepo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Users_AccountOwnerId1",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_AccountOwnerId1",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AccountOwnerId1",
                table: "Accounts");

            migrationBuilder.AlterColumn<int>(
                name: "AccountOwnerId",
                table: "Accounts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountOwnerId",
                table: "Accounts",
                column: "AccountOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Users_AccountOwnerId",
                table: "Accounts",
                column: "AccountOwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Users_AccountOwnerId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_AccountOwnerId",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "AccountOwnerId",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
