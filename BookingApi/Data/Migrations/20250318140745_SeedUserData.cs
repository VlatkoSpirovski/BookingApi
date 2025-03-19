using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9404b88a-b6f4-411d-8281-c00e5645c0a3");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Birthday", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Profession", "SecurityStamp", "State", "TwoFactorEnabled", "UserId", "UserName", "ZipCode" },
                values: new object[] { "9404b88a-b6f4-411d-8281-c00e5645c0a5", 0, null, null, null, "54b7df74-2678-4666-82ac-76b96359c329", null, true, null, null, false, null, "ADMIN@EXAMPLE.COM", null, null, null, false, null, "693a621e-902d-4ff8-bc9e-9e0048010a47", null, false, "bookingUser1", null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9404b88a-b6f4-411d-8281-c00e5645c0a5");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Birthday", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Profession", "SecurityStamp", "State", "TwoFactorEnabled", "UserId", "UserName", "ZipCode" },
                values: new object[] { "9404b88a-b6f4-411d-8281-c00e5645c0a3", 0, null, null, null, "13b71299-28fd-47a1-91ed-1e8a63f407af", null, true, null, null, false, null, "ADMIN@EXAMPLE.COM", null, null, null, false, null, "c42669ca-3e8e-45ba-92ce-891dc5f78438", null, false, "bookingUser1", null, null });
        }
    }
}
