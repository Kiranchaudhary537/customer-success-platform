using Promact.CustomerSuccess.Platform.Services.Dtos.ApprovedTeamDtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities.Auditing;

namespace Promact.CustomerSuccess.Platform.Entities
{
    public class Project : AuditedEntity<Guid>
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string ProjectManager { get; set; }
        public required string Status { get; set; }
        public required string Member { get; set; }
        public virtual ICollection<Document>? Documents { get; set; }
        public virtual ICollection<ProjectBudget>? Budgets { get; set; }
        public virtual ICollection<EscalationMatrix>? EscalationMatrices { get; set; }
        public virtual ICollection<RiskProfile>? RiskProfiles { get; set; }
        public virtual ICollection<PhaseMilestone>? PhaseMilestones { get; set; }
        public virtual ICollection<ProjectResources>? Resources { get; set; }
        public virtual ICollection<ClientFeedback>? ClientFeedbacks { get; set; }
        public virtual ICollection<MeetingMinute>? MeetingMinutes { get; set; }
        public virtual ICollection<ApprovedTeam>? ApprovedTeams { get; set; }
        public virtual ICollection<AuditHistory>? AuditHistories { get; set; }
        public virtual ICollection<ProjectOverview>? ProjectOverviews { get; set; }
        public virtual ICollection<ProjectUpdate>? ProjectUpdates { get; set; }
        public virtual ICollection<Sprint>? Sprints { get; set; }
        public virtual ICollection<StakeAndScope>? StakeAndScopes { get; set; }
        public virtual ICollection<Stakeholder>? Stakeholders { get; set; }
        public virtual ICollection<VersionHistory>? VersionHistories { get; set; }

    }
}
