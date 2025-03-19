using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class FieldsForTotalRoomsInPropertyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfBalconies",
                table: "Properties",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfBedrooms",
                table: "Properties",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfKitchens",
                table: "Properties",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfLivingRooms",
                table: "Properties",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9404b88a-b6f4-411d-8281-c00e5645c0a5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d03436d2-0b64-46e5-b19e-b1809680f76b", "52799490-8239-47c3-96e4-54169b915936" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfBalconies",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "NumberOfBedrooms",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "NumberOfKitchens",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "NumberOfLivingRooms",
                table: "Properties");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9404b88a-b6f4-411d-8281-c00e5645c0a5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "00f5f2bc-b3c4-4f8a-9a17-58f87842a200", "09f8fcc1-70e1-4ad4-ba2b-87cd38320e88" });
        }
    }
}
