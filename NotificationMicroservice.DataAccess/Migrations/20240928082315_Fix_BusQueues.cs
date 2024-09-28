using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotificationMicroservice.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Fix_BusQueues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EventQueues",
                table: "BusQueues",
                newName: "QueueName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QueueName",
                table: "BusQueues",
                newName: "EventQueues");
        }
    }
}
