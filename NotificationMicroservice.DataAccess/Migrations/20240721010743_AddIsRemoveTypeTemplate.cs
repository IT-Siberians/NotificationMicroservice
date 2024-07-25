using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotificationMicroservice.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddIsRemoveTypeTemplate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Types_TypesId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Templates_Types_TypesId",
                table: "Templates");

            migrationBuilder.DropIndex(
                name: "IX_Templates_TypesId",
                table: "Templates");

            migrationBuilder.DropIndex(
                name: "IX_Messages_TypesId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "TypesId",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "TypesId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Templates",
                newName: "IsRemove");

            migrationBuilder.AddColumn<bool>(
                name: "IsRemove",
                table: "Types",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Templates_TypeId",
                table: "Templates",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_TypeId",
                table: "Messages",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Types_TypeId",
                table: "Messages",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Templates_Types_TypeId",
                table: "Templates",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Types_TypeId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Templates_Types_TypeId",
                table: "Templates");

            migrationBuilder.DropIndex(
                name: "IX_Templates_TypeId",
                table: "Templates");

            migrationBuilder.DropIndex(
                name: "IX_Messages_TypeId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "IsRemove",
                table: "Types");

            migrationBuilder.RenameColumn(
                name: "IsRemove",
                table: "Templates",
                newName: "IsActive");

            migrationBuilder.AddColumn<Guid>(
                name: "TypesId",
                table: "Templates",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TypesId",
                table: "Messages",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Templates_TypesId",
                table: "Templates",
                column: "TypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_TypesId",
                table: "Messages",
                column: "TypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Types_TypesId",
                table: "Messages",
                column: "TypesId",
                principalTable: "Types",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Templates_Types_TypesId",
                table: "Templates",
                column: "TypesId",
                principalTable: "Types",
                principalColumn: "Id");
        }
    }
}
