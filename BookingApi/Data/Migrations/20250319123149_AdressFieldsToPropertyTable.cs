using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdressFieldsToPropertyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Properties",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Properties",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Properties",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Properties",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Properties",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9404b88a-b6f4-411d-8281-c00e5645c0a5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7784edf7-41cf-4e94-b48f-1121f67d6725", "e0bbb366-479d-43d9-a0d9-4a847a89e9b2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Properties");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9404b88a-b6f4-411d-8281-c00e5645c0a5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d03436d2-0b64-46e5-b19e-b1809680f76b", "52799490-8239-47c3-96e4-54169b915936" });
        }
    }
}
