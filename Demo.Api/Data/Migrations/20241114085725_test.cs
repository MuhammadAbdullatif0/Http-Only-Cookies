using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Api.data.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "767e4d7b-fe0a-475c-8cc4-55a8c9fee0cc");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "12624b43-dbbc-4aaf-bb87-1a7e22123c41", 0, "3d8787d1-3e16-4d58-ae68-fca05acee581", "test@test.com", true, "M TEFA", false, null, "TEST@TEST.COM", "MUHAMMAD", "AQAAAAIAAYagAAAAEFUtDIT9yuCOdW94IQEpcejM21lmPTaUy6qq+DQVZHvb5Ze7LoSTaMZru0ZsvALbDQ==", null, false, "d40d2c89-49df-42ea-88ba-fc1ce388b5e8", false, "Muhammad" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "12624b43-dbbc-4aaf-bb87-1a7e22123c41");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "767e4d7b-fe0a-475c-8cc4-55a8c9fee0cc", 0, "6cbc92ec-2ced-49f4-9e4b-d605483a3d9d", "test@test.com", true, "M TEFA", false, null, "TEST@TEST.COM", "MUHAMMAD", "AQAAAAIAAYagAAAAEAwf8ToBZi77zPmhbTY1egZv0kPltlmrvBrmHU39b/+7GWWhjT1J2eEmTc+3w/SHrA==", null, false, "94bd20f7-6f52-44ff-a7b5-a087e1983b31", false, "Muhammad" });
        }
    }
}
