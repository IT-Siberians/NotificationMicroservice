using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotificationMicroservice.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Add_Table_BusQueue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Template",
                table: "Templates",
                type: "character varying(600)",
                maxLength: 600,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "BusQueues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EventQueues = table.Column<string>(type: "text", nullable: false),
                    TypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsRemoved = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusQueues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusQueues_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusQueues_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusQueues_Users_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusQueues_CreatedByUserId",
                table: "BusQueues",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BusQueues_ModifiedByUserId",
                table: "BusQueues",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BusQueues_TypeId",
                table: "BusQueues",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusQueues");

            migrationBuilder.AlterColumn<string>(
                name: "Template",
                table: "Templates",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(600)",
                oldMaxLength: 600);
        }
    }
}
