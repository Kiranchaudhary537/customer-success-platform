using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Promact.CustomerSuccess.Platform.Migrations
{
    /// <inheritdoc />
    public partial class Added_new_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectBudgets_BudgetId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_BudgetId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Goals",
                table: "Sprints");

            migrationBuilder.DropColumn(
                name: "SprintNumber",
                table: "Sprints");

            migrationBuilder.DropColumn(
                name: "BudgetId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "PhaseMilestones");

            migrationBuilder.AddColumn<DateTime>(
                name: "ClosureDate",
                table: "RiskProfiles",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "RiskProfiles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "RiskProfiles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Member",
                table: "Projects",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProjectManager",
                table: "Projects",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Projects",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "ProjectResources",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProjectResources",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "ProjectBudgets",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovalDate",
                table: "PhaseMilestones",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RevisedDate",
                table: "PhaseMilestones",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "ActionTaken",
                table: "ClientFeedbacks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ClosureDate",
                table: "ClientFeedbacks",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "ClientFeedbacks",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "ClientFeedbacks",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "ClientFeedbacks",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "ClientFeedbacks",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApprovedTeams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NumberOfResources = table.Column<int>(type: "integer", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    AvailabilityPercentage = table.Column<int>(type: "integer", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    PhaseMilestoneId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovedTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApprovedTeams_PhaseMilestones_PhaseMilestoneId",
                        column: x => x.PhaseMilestoneId,
                        principalTable: "PhaseMilestones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovedTeams_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuditHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DateOfAudit = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ReviewedBy = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Section = table.Column<string>(type: "text", nullable: false),
                    CommentQueries = table.Column<string>(type: "text", nullable: false),
                    ActionItem = table.Column<string>(type: "text", nullable: false),
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
                    table.PrimaryKey("PK_AuditHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditHistory_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuditHistory_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AuditHistory_Users_LastModifierId",
                        column: x => x.LastModifierId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectBudgets_ProjectId",
                table: "ProjectBudgets",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovedTeams_PhaseMilestoneId",
                table: "ApprovedTeams",
                column: "PhaseMilestoneId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovedTeams_ProjectId",
                table: "ApprovedTeams",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditHistory_CreatorId",
                table: "AuditHistory",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditHistory_LastModifierId",
                table: "AuditHistory",
                column: "LastModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditHistory_ProjectId",
                table: "AuditHistory",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectBudgets_Projects_ProjectId",
                table: "ProjectBudgets",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectBudgets_Projects_ProjectId",
                table: "ProjectBudgets");

            migrationBuilder.DropTable(
                name: "ApprovedTeams");

            migrationBuilder.DropTable(
                name: "AuditHistory");

            migrationBuilder.DropIndex(
                name: "IX_ProjectBudgets_ProjectId",
                table: "ProjectBudgets");

            migrationBuilder.DropColumn(
                name: "ClosureDate",
                table: "RiskProfiles");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "RiskProfiles");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "RiskProfiles");

            migrationBuilder.DropColumn(
                name: "Member",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectManager",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "ProjectResources");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProjectResources");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "ProjectBudgets");

            migrationBuilder.DropColumn(
                name: "ApprovalDate",
                table: "PhaseMilestones");

            migrationBuilder.DropColumn(
                name: "RevisedDate",
                table: "PhaseMilestones");

            migrationBuilder.DropColumn(
                name: "ActionTaken",
                table: "ClientFeedbacks");

            migrationBuilder.DropColumn(
                name: "ClosureDate",
                table: "ClientFeedbacks");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "ClientFeedbacks");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "ClientFeedbacks");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "ClientFeedbacks");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "ClientFeedbacks");

            migrationBuilder.AddColumn<string>(
                name: "Goals",
                table: "Sprints",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SprintNumber",
                table: "Sprints",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "BudgetId",
                table: "Projects",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PhaseMilestones",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_BudgetId",
                table: "Projects",
                column: "BudgetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectBudgets_BudgetId",
                table: "Projects",
                column: "BudgetId",
                principalTable: "ProjectBudgets",
                principalColumn: "Id");
        }
    }
}
