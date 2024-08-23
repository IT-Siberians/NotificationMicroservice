using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotificationMicroservice.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixNaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifyUserName",
                table: "Types",
                newName: "ModifiedUserName");

            migrationBuilder.RenameColumn(
                name: "ModifyDate",
                table: "Types",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreateUserName",
                table: "Types",
                newName: "CreatedUserName");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Types",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "ModifyUserName",
                table: "Templates",
                newName: "ModifiedUserName");

            migrationBuilder.RenameColumn(
                name: "ModifyDate",
                table: "Templates",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreateUserName",
                table: "Templates",
                newName: "CreatedUserName");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Templates",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Messages",
                newName: "CreatedDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedUserName",
                table: "Types",
                newName: "ModifyUserName");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Types",
                newName: "ModifyDate");

            migrationBuilder.RenameColumn(
                name: "CreatedUserName",
                table: "Types",
                newName: "CreateUserName");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Types",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedUserName",
                table: "Templates",
                newName: "ModifyUserName");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Templates",
                newName: "ModifyDate");

            migrationBuilder.RenameColumn(
                name: "CreatedUserName",
                table: "Templates",
                newName: "CreateUserName");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Templates",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Messages",
                newName: "CreateDate");
        }
    }
}
