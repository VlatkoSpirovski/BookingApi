using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRentalModelInPropertyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RentalModel",
                table: "Properties",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9404b88a-b6f4-411d-8281-c00e5645c0a5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "dedea5d4-6b8c-4889-9b1d-3c9cbd58f991", "38438fc3-9281-471a-9fa2-43100650f806" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RentalModel",
                table: "Properties");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9404b88a-b6f4-411d-8281-c00e5645c0a5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1caf4dea-2e45-497d-9a8d-f4714fa6bd95", "5ddc8b00-6558-4019-9db5-30ee945f8085" });
        }
    }
}
