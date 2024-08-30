using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotificationMicroservice.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixNaming3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Types",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Templates",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Messages",
                newName: "CreationDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Types",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Templates",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Messages",
                newName: "CreatedDate");
        }
    }
}
