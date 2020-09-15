using Microsoft.EntityFrameworkCore.Migrations;

namespace AmparoX.PermissionApp.Persistence.Migrations
{
    public partial class InitialMigration2s2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Permissions_PermissionTypeId",
                table: "Permissions");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_PermissionTypeId",
                table: "Permissions",
                column: "PermissionTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Permissions_PermissionTypeId",
                table: "Permissions");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_PermissionTypeId",
                table: "Permissions",
                column: "PermissionTypeId",
                unique: true);
        }
    }
}
