using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Promact.CustomerSuccess.Platform.Migrations
{
    /// <inheritdoc />
    public partial class added_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditHistory_Users_CreatorId",
                table: "AuditHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_AuditHistory_Users_LastModifierId",
                table: "AuditHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentVersions_Users_CreatorId",
                table: "DocumentVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentVersions_Users_LastModifierId",
                table: "DocumentVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_EscalationMatrices_Users_CreatorId",
                table: "EscalationMatrices");

            migrationBuilder.DropForeignKey(
                name: "FK_EscalationMatrices_Users_LastModifierId",
                table: "EscalationMatrices");

            migrationBuilder.DropForeignKey(
                name: "FK_MeetingMinutes_Users_CreatorId",
                table: "MeetingMinutes");

            migrationBuilder.DropForeignKey(
                name: "FK_MeetingMinutes_Users_LastModifierId",
                table: "MeetingMinutes");

            migrationBuilder.DropForeignKey(
                name: "FK_PhaseMilestones_Users_CreatorId",
                table: "PhaseMilestones");

            migrationBuilder.DropForeignKey(
                name: "FK_PhaseMilestones_Users_LastModifierId",
                table: "PhaseMilestones");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectBudgets_Users_CreatorId",
                table: "ProjectBudgets");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectBudgets_Users_LastModifierId",
                table: "ProjectBudgets");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectResources_Users_CreatorId",
                table: "ProjectResources");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectResources_Users_LastModifierId",
                table: "ProjectResources");

            migrationBuilder.DropForeignKey(
                name: "FK_RemediationStep_RiskProfiles_RiskProfileId",
                table: "RemediationStep");

            migrationBuilder.DropForeignKey(
                name: "FK_RemediationStep_Users_CreatorId",
                table: "RemediationStep");

            migrationBuilder.DropForeignKey(
                name: "FK_RemediationStep_Users_LastModifierId",
                table: "RemediationStep");

            migrationBuilder.DropForeignKey(
                name: "FK_RiskProfiles_Users_CreatorId",
                table: "RiskProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_RiskProfiles_Users_LastModifierId",
                table: "RiskProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Sprints_Users_CreatorId",
                table: "Sprints");

            migrationBuilder.DropForeignKey(
                name: "FK_Sprints_Users_LastModifierId",
                table: "Sprints");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Organizations_TenantId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_ProjectResources_CreatorId",
                table: "ProjectResources");

            migrationBuilder.DropIndex(
                name: "IX_ProjectResources_LastModifierId",
                table: "ProjectResources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RemediationStep",
                table: "RemediationStep");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "ProjectResources");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "ProjectResources");

            migrationBuilder.DropColumn(
                name: "Resource",
                table: "ProjectResources");

            migrationBuilder.DropColumn(
                name: "ResourceId",
                table: "ProjectResources");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "ApplicationUser");

            migrationBuilder.RenameTable(
                name: "RemediationStep",
                newName: "RemediationSteps");

            migrationBuilder.RenameIndex(
                name: "IX_Users_TenantId",
                table: "ApplicationUser",
                newName: "IX_ApplicationUser_TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_RemediationStep_RiskProfileId",
                table: "RemediationSteps",
                newName: "IX_RemediationSteps_RiskProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_RemediationStep_LastModifierId",
                table: "RemediationSteps",
                newName: "IX_RemediationSteps_LastModifierId");

            migrationBuilder.RenameIndex(
                name: "IX_RemediationStep_CreatorId",
                table: "RemediationSteps",
                newName: "IX_RemediationSteps_CreatorId");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "ProjectResources",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUser",
                table: "ApplicationUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RemediationSteps",
                table: "RemediationSteps",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProjectOverviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Brief = table.Column<string>(type: "text", nullable: false),
                    Purpose = table.Column<string>(type: "text", nullable: false),
                    Goals = table.Column<string>(type: "text", nullable: false),
                    Objectives = table.Column<string>(type: "text", nullable: false),
                    Budget = table.Column<string>(type: "text", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectOverviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectOverviews_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectUpdates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    GeneralUpdates = table.Column<string>(type: "text", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUpdates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectUpdates_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StakeAndScopes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Stake = table.Column<string>(type: "text", nullable: false),
                    Scope = table.Column<string>(type: "text", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StakeAndScopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StakeAndScopes_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stakeholders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ContactEmail = table.Column<string>(type: "text", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stakeholders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stakeholders_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VersionHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Version = table.Column<string>(type: "text", nullable: false),
                    Change = table.Column<string>(type: "text", nullable: false),
                    ChangeReason = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    RevisionDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ApprovedBy = table.Column<string>(type: "text", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VersionHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VersionHistories_ApplicationUser_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VersionHistories_ApplicationUser_LastModifierId",
                        column: x => x.LastModifierId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectOverviews_ProjectId",
                table: "ProjectOverviews",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUpdates_ProjectId",
                table: "ProjectUpdates",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StakeAndScopes_ProjectId",
                table: "StakeAndScopes",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Stakeholders_ProjectId",
                table: "Stakeholders",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_VersionHistories_CreatorId",
                table: "VersionHistories",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_VersionHistories_LastModifierId",
                table: "VersionHistories",
                column: "LastModifierId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_Organizations_TenantId",
                table: "ApplicationUser",
                column: "TenantId",
                principalTable: "Organizations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditHistory_ApplicationUser_CreatorId",
                table: "AuditHistory",
                column: "CreatorId",
                principalTable: "ApplicationUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditHistory_ApplicationUser_LastModifierId",
                table: "AuditHistory",
                column: "LastModifierId",
                principalTable: "ApplicationUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentVersions_ApplicationUser_CreatorId",
                table: "DocumentVersions",
                column: "CreatorId",
                principalTable: "ApplicationUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentVersions_ApplicationUser_LastModifierId",
                table: "DocumentVersions",
                column: "LastModifierId",
                principalTable: "ApplicationUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EscalationMatrices_ApplicationUser_CreatorId",
                table: "EscalationMatrices",
                column: "CreatorId",
                principalTable: "ApplicationUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EscalationMatrices_ApplicationUser_LastModifierId",
                table: "EscalationMatrices",
                column: "LastModifierId",
                principalTable: "ApplicationUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingMinutes_ApplicationUser_CreatorId",
                table: "MeetingMinutes",
                column: "CreatorId",
                principalTable: "ApplicationUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingMinutes_ApplicationUser_LastModifierId",
                table: "MeetingMinutes",
                column: "LastModifierId",
                principalTable: "ApplicationUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhaseMilestones_ApplicationUser_CreatorId",
                table: "PhaseMilestones",
                column: "CreatorId",
                principalTable: "ApplicationUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhaseMilestones_ApplicationUser_LastModifierId",
                table: "PhaseMilestones",
                column: "LastModifierId",
                principalTable: "ApplicationUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectBudgets_ApplicationUser_CreatorId",
                table: "ProjectBudgets",
                column: "CreatorId",
                principalTable: "ApplicationUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectBudgets_ApplicationUser_LastModifierId",
                table: "ProjectBudgets",
                column: "LastModifierId",
                principalTable: "ApplicationUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RemediationSteps_ApplicationUser_CreatorId",
                table: "RemediationSteps",
                column: "CreatorId",
                principalTable: "ApplicationUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RemediationSteps_ApplicationUser_LastModifierId",
                table: "RemediationSteps",
                column: "LastModifierId",
                principalTable: "ApplicationUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RemediationSteps_RiskProfiles_RiskProfileId",
                table: "RemediationSteps",
                column: "RiskProfileId",
                principalTable: "RiskProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RiskProfiles_ApplicationUser_CreatorId",
                table: "RiskProfiles",
                column: "CreatorId",
                principalTable: "ApplicationUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RiskProfiles_ApplicationUser_LastModifierId",
                table: "RiskProfiles",
                column: "LastModifierId",
                principalTable: "ApplicationUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sprints_ApplicationUser_CreatorId",
                table: "Sprints",
                column: "CreatorId",
                principalTable: "ApplicationUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sprints_ApplicationUser_LastModifierId",
                table: "Sprints",
                column: "LastModifierId",
                principalTable: "ApplicationUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUser_Organizations_TenantId",
                table: "ApplicationUser");

            migrationBuilder.DropForeignKey(
                name: "FK_AuditHistory_ApplicationUser_CreatorId",
                table: "AuditHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_AuditHistory_ApplicationUser_LastModifierId",
                table: "AuditHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentVersions_ApplicationUser_CreatorId",
                table: "DocumentVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentVersions_ApplicationUser_LastModifierId",
                table: "DocumentVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_EscalationMatrices_ApplicationUser_CreatorId",
                table: "EscalationMatrices");

            migrationBuilder.DropForeignKey(
                name: "FK_EscalationMatrices_ApplicationUser_LastModifierId",
                table: "EscalationMatrices");

            migrationBuilder.DropForeignKey(
                name: "FK_MeetingMinutes_ApplicationUser_CreatorId",
                table: "MeetingMinutes");

            migrationBuilder.DropForeignKey(
                name: "FK_MeetingMinutes_ApplicationUser_LastModifierId",
                table: "MeetingMinutes");

            migrationBuilder.DropForeignKey(
                name: "FK_PhaseMilestones_ApplicationUser_CreatorId",
                table: "PhaseMilestones");

            migrationBuilder.DropForeignKey(
                name: "FK_PhaseMilestones_ApplicationUser_LastModifierId",
                table: "PhaseMilestones");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectBudgets_ApplicationUser_CreatorId",
                table: "ProjectBudgets");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectBudgets_ApplicationUser_LastModifierId",
                table: "ProjectBudgets");

            migrationBuilder.DropForeignKey(
                name: "FK_RemediationSteps_ApplicationUser_CreatorId",
                table: "RemediationSteps");

            migrationBuilder.DropForeignKey(
                name: "FK_RemediationSteps_ApplicationUser_LastModifierId",
                table: "RemediationSteps");

            migrationBuilder.DropForeignKey(
                name: "FK_RemediationSteps_RiskProfiles_RiskProfileId",
                table: "RemediationSteps");

            migrationBuilder.DropForeignKey(
                name: "FK_RiskProfiles_ApplicationUser_CreatorId",
                table: "RiskProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_RiskProfiles_ApplicationUser_LastModifierId",
                table: "RiskProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Sprints_ApplicationUser_CreatorId",
                table: "Sprints");

            migrationBuilder.DropForeignKey(
                name: "FK_Sprints_ApplicationUser_LastModifierId",
                table: "Sprints");

            migrationBuilder.DropTable(
                name: "ProjectOverviews");

            migrationBuilder.DropTable(
                name: "ProjectUpdates");

            migrationBuilder.DropTable(
                name: "StakeAndScopes");

            migrationBuilder.DropTable(
                name: "Stakeholders");

            migrationBuilder.DropTable(
                name: "VersionHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RemediationSteps",
                table: "RemediationSteps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUser",
                table: "ApplicationUser");

            migrationBuilder.RenameTable(
                name: "RemediationSteps",
                newName: "RemediationStep");

            migrationBuilder.RenameTable(
                name: "ApplicationUser",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_RemediationSteps_RiskProfileId",
                table: "RemediationStep",
                newName: "IX_RemediationStep_RiskProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_RemediationSteps_LastModifierId",
                table: "RemediationStep",
                newName: "IX_RemediationStep_LastModifierId");

            migrationBuilder.RenameIndex(
                name: "IX_RemediationSteps_CreatorId",
                table: "RemediationStep",
                newName: "IX_RemediationStep_CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUser_TenantId",
                table: "Users",
                newName: "IX_Users_TenantId");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "ProjectResources",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "ProjectResources",
                type: "character varying(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "ProjectResources",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "Resource",
                table: "ProjectResources",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ResourceId",
                table: "ProjectResources",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_RemediationStep",
                table: "RemediationStep",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectResources_CreatorId",
                table: "ProjectResources",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectResources_LastModifierId",
                table: "ProjectResources",
                column: "LastModifierId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentVersions_Users_CreatorId",
                table: "DocumentVersions",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentVersions_Users_LastModifierId",
                table: "DocumentVersions",
                column: "LastModifierId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EscalationMatrices_Users_CreatorId",
                table: "EscalationMatrices",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EscalationMatrices_Users_LastModifierId",
                table: "EscalationMatrices",
                column: "LastModifierId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingMinutes_Users_CreatorId",
                table: "MeetingMinutes",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingMinutes_Users_LastModifierId",
                table: "MeetingMinutes",
                column: "LastModifierId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhaseMilestones_Users_CreatorId",
                table: "PhaseMilestones",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhaseMilestones_Users_LastModifierId",
                table: "PhaseMilestones",
                column: "LastModifierId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectBudgets_Users_CreatorId",
                table: "ProjectBudgets",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectBudgets_Users_LastModifierId",
                table: "ProjectBudgets",
                column: "LastModifierId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectResources_Users_CreatorId",
                table: "ProjectResources",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectResources_Users_LastModifierId",
                table: "ProjectResources",
                column: "LastModifierId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RemediationStep_RiskProfiles_RiskProfileId",
                table: "RemediationStep",
                column: "RiskProfileId",
                principalTable: "RiskProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RemediationStep_Users_CreatorId",
                table: "RemediationStep",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RemediationStep_Users_LastModifierId",
                table: "RemediationStep",
                column: "LastModifierId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RiskProfiles_Users_CreatorId",
                table: "RiskProfiles",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RiskProfiles_Users_LastModifierId",
                table: "RiskProfiles",
                column: "LastModifierId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sprints_Users_CreatorId",
                table: "Sprints",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sprints_Users_LastModifierId",
                table: "Sprints",
                column: "LastModifierId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Organizations_TenantId",
                table: "Users",
                column: "TenantId",
                principalTable: "Organizations",
                principalColumn: "Id");
        }
    }
}
