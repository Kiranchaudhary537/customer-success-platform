using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Promact.CustomerSuccess.Platform.Migrations
{
    /// <inheritdoc />
    public partial class update_audithistory_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditHistory_Projects_ProjectId1",
                table: "AuditHistory");

            migrationBuilder.RenameColumn(
                name: "ProjectId1",
                table: "AuditHistory",
                newName: "LastModifierId");

            migrationBuilder.RenameIndex(
                name: "IX_AuditHistory_ProjectId1",
                table: "AuditHistory",
                newName: "IX_AuditHistory_LastModifierId");

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "AuditHistory",
                type: "character varying(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "AuditHistory",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "AuditHistory",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "AuditHistory",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "AuditHistory",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuditHistory_CreatorId",
                table: "AuditHistory",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditHistory_Users_CreatorId",
                table: "AuditHistory",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditHistory_Users_LastModifierId",
                table: "AuditHistory",
                column: "LastModifierId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditHistory_Users_CreatorId",
                table: "AuditHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_AuditHistory_Users_LastModifierId",
                table: "AuditHistory");

            migrationBuilder.DropIndex(
                name: "IX_AuditHistory_CreatorId",
                table: "AuditHistory");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "AuditHistory");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "AuditHistory");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "AuditHistory");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "AuditHistory");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "AuditHistory");

            migrationBuilder.RenameColumn(
                name: "LastModifierId",
                table: "AuditHistory",
                newName: "ProjectId1");

            migrationBuilder.RenameIndex(
                name: "IX_AuditHistory_LastModifierId",
                table: "AuditHistory",
                newName: "IX_AuditHistory_ProjectId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditHistory_Projects_ProjectId1",
                table: "AuditHistory",
                column: "ProjectId1",
                principalTable: "Projects",
                principalColumn: "Id");
        }
    }
}
