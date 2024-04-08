using Promact.CustomerSuccess.Platform.Entities;
using Promact.CustomerSuccess.Platform.Services.Dtos.ApprovedTeamDtos;
using Promact.CustomerSuccess.Platform.Services.Dtos.ClientFeedbackDtos;
using Promact.CustomerSuccess.Platform.Services.Dtos.EscalationMatrixDtos;
using Promact.CustomerSuccess.Platform.Services.Dtos.MeetingMinuteDtos;
using Promact.CustomerSuccess.Platform.Services.Dtos.ProjectBudgetDtos;
using Promact.CustomerSuccess.Platform.Services.Dtos.ProjectResourceDtos;
using Promact.CustomerSuccess.Platform.Services.Dtos.RiskProfileDtos;
using Volo.Abp.Application.Dtos;

namespace Promact.CustomerSuccess.Platform.Services.Dtos.ProjectDtos
{
  public class ProjectDto:IEntityDto<Guid>
  {
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string ProjectManager { get; set; }
    public required string Status { get; set; }
    public required string Member { get; set; }
    public IEnumerable<DocumentDto>? Documents { get; set; }
    public IEnumerable<ProjectBudgetDto>? Budgets { get; set; }
    public IEnumerable<EscalationMatrixDto>? EscalationMatrices { get; set; }
    public IEnumerable<RiskProfileDto>? RiskProfiles { get; set; }
    public IEnumerable<PhaseMilestone>? PhaseMilestones { get; set; }
    public IEnumerable<ProjectResourceDto>? Resources { get; set; }
    public IEnumerable<ClientFeedbackDto>? ClientFeedbacks { get; set; }
    public IEnumerable<MeetingMinuteDto>? MeetingMinutes { get; set; }
    public IEnumerable<ApprovedTeam>? ApprovedTeams { get; set; }
        public virtual IEnumerable<ProjectOverview>? ProjectOverviews { get; set; }
        public virtual IEnumerable<ProjectUpdate>? ProjectUpdates { get; set; }
        public virtual IEnumerable<Sprint>? Sprints { get; set; }
        public virtual IEnumerable<StakeAndScope>? StakeAndScopes { get; set; }
        public virtual IEnumerable<Stakeholder>? Stakeholders { get; set; }
        public virtual IEnumerable<VersionHistory>? VersionHistories { get; set; }

    }
}
