using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace concert_booking_service_csharp.Migrations
{
    /// <inheritdoc />
    public partial class _24072024DatabaseUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Admin",
                newName: "AdminId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdminId",
                table: "Admin",
                newName: "UserId");
        }
    }
}
