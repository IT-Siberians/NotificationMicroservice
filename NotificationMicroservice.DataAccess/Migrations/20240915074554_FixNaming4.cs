using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotificationMicroservice.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixNaming4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Templates_Users_CreatedUserId",
                table: "Templates");

            migrationBuilder.DropForeignKey(
                name: "FK_Templates_Users_ModifiedUserId",
                table: "Templates");

            migrationBuilder.DropForeignKey(
                name: "FK_Types_Users_CreatedUserId",
                table: "Types");

            migrationBuilder.DropForeignKey(
                name: "FK_Types_Users_ModifiedUserId",
                table: "Types");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "ModifiedUserId",
                table: "Types",
                newName: "ModifiedByUserId");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Types",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId",
                table: "Types",
                newName: "CreatedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Types_ModifiedUserId",
                table: "Types",
                newName: "IX_Types_ModifiedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Types_CreatedUserId",
                table: "Types",
                newName: "IX_Types_CreatedByUserId");

            migrationBuilder.RenameColumn(
                name: "ModifiedUserId",
                table: "Templates",
                newName: "ModifiedByUserId");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Templates",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId",
                table: "Templates",
                newName: "CreatedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Templates_ModifiedUserId",
                table: "Templates",
                newName: "IX_Templates_ModifiedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Templates_CreatedUserId",
                table: "Templates",
                newName: "IX_Templates_CreatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Templates_Users_CreatedByUserId",
                table: "Templates",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Templates_Users_ModifiedByUserId",
                table: "Templates",
                column: "ModifiedByUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Types_Users_CreatedByUserId",
                table: "Types",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Types_Users_ModifiedByUserId",
                table: "Types",
                column: "ModifiedByUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Templates_Users_CreatedByUserId",
                table: "Templates");

            migrationBuilder.DropForeignKey(
                name: "FK_Templates_Users_ModifiedByUserId",
                table: "Templates");

            migrationBuilder.DropForeignKey(
                name: "FK_Types_Users_CreatedByUserId",
                table: "Types");

            migrationBuilder.DropForeignKey(
                name: "FK_Types_Users_ModifiedByUserId",
                table: "Types");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "ModifiedByUserId",
                table: "Types",
                newName: "ModifiedUserId");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Types",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserId",
                table: "Types",
                newName: "CreatedUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Types_ModifiedByUserId",
                table: "Types",
                newName: "IX_Types_ModifiedUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Types_CreatedByUserId",
                table: "Types",
                newName: "IX_Types_CreatedUserId");

            migrationBuilder.RenameColumn(
                name: "ModifiedByUserId",
                table: "Templates",
                newName: "ModifiedUserId");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Templates",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserId",
                table: "Templates",
                newName: "CreatedUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Templates_ModifiedByUserId",
                table: "Templates",
                newName: "IX_Templates_ModifiedUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Templates_CreatedByUserId",
                table: "Templates",
                newName: "IX_Templates_CreatedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Templates_Users_CreatedUserId",
                table: "Templates",
                column: "CreatedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Templates_Users_ModifiedUserId",
                table: "Templates",
                column: "ModifiedUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Types_Users_CreatedUserId",
                table: "Types",
                column: "CreatedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Types_Users_ModifiedUserId",
                table: "Types",
                column: "ModifiedUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
