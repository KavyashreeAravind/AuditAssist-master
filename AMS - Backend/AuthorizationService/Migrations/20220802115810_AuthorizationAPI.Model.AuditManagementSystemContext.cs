using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthorizationService.Migrations
{
    public partial class AuthorizationServiceModelAuditManagementSystemContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Audit",
                columns: table => new
                {
                    auditid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ProjectManagerName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ApplicationOwnerName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    AuditType = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    AuditDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ProjectExecutionStatus = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    RemedialActionDuration = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit", x => x.auditid);
                });

            migrationBuilder.CreateTable(
                name: "Userdetails",
                columns: table => new
                {
                    userid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    password = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    RefreshToken = table.Column<string>(nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Userdeta__CBA1B2570286273E", x => x.userid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audit");

            migrationBuilder.DropTable(
                name: "Userdetails");
        }
    }
}
