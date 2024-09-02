using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotificationMicroservice.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedUserName",
                table: "Types");

            migrationBuilder.DropColumn(
                name: "ModifiedUserName",
                table: "Types");

            migrationBuilder.DropColumn(
                name: "CreatedUserName",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "ModifiedUserName",
                table: "Templates");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                table: "Types",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedUserId",
                table: "Types",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                table: "Templates",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedUserId",
                table: "Templates",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Types_CreatedUserId",
                table: "Types",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Types_ModifiedUserId",
                table: "Types",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Templates_CreatedUserId",
                table: "Templates",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Templates_ModifiedUserId",
                table: "Templates",
                column: "ModifiedUserId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Types_CreatedUserId",
                table: "Types");

            migrationBuilder.DropIndex(
                name: "IX_Types_ModifiedUserId",
                table: "Types");

            migrationBuilder.DropIndex(
                name: "IX_Templates_CreatedUserId",
                table: "Templates");

            migrationBuilder.DropIndex(
                name: "IX_Templates_ModifiedUserId",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Types");

            migrationBuilder.DropColumn(
                name: "ModifiedUserId",
                table: "Types");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "ModifiedUserId",
                table: "Templates");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserName",
                table: "Types",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedUserName",
                table: "Types",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserName",
                table: "Templates",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedUserName",
                table: "Templates",
                type: "text",
                nullable: true);
        }
    }
}
