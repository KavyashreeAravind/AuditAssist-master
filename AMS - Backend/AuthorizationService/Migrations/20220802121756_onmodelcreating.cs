using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthorizationService.Migrations
{
    public partial class onmodelcreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Userdetails",
                columns: new[] { "Userid", "Email", "Password", "RefreshToken", "RefreshTokenExpiryTime" },
                values: new object[] { 1, "kavya@gmail.com", "abc@123", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Userdetails",
                keyColumn: "Userid",
                keyValue: 1);
        }
    }
}
