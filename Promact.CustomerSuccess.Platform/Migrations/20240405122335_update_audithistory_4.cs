using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Promact.CustomerSuccess.Platform.Migrations
{
    /// <inheritdoc />
    public partial class update_audithistory_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditHistory_Projects_ProjectId1",
                table: "AuditHistory");

            migrationBuilder.DropIndex(
                name: "IX_AuditHistory_ProjectId1",
                table: "AuditHistory");

            migrationBuilder.DropColumn(
                name: "ProjectId1",
                table: "AuditHistory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId1",
                table: "AuditHistory",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuditHistory_ProjectId1",
                table: "AuditHistory",
                column: "ProjectId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditHistory_Projects_ProjectId1",
                table: "AuditHistory",
                column: "ProjectId1",
                principalTable: "Projects",
                principalColumn: "Id");
        }
    }
}
