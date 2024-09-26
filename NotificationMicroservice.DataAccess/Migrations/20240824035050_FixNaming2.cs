using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotificationMicroservice.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixNaming2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsRemove",
                table: "Types",
                newName: "IsRemoved");

            migrationBuilder.RenameColumn(
                name: "IsRemove",
                table: "Templates",
                newName: "IsRemoved");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "Types",
                newName: "IsRemove");

            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "Templates",
                newName: "IsRemove");
        }
    }
}
