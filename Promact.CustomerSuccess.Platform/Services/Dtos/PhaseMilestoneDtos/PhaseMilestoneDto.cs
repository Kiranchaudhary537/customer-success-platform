using Promact.CustomerSuccess.Platform.Entities;
using Promact.CustomerSuccess.Platform.Services.Dtos.ApprovedTeamDtos;
using Promact.CustomerSuccess.Platform.Services.Services;
using Volo.Abp.Application.Dtos;

namespace Promact.CustomerSuccess.Platform.Services.Dtos.PhaseDtos
{
  public class PhaseMilestoneDto : IEntityDto<Guid>
  {
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public required string Title { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? CompletionDate { get; set; }

    public DateTime? ApprovalDate { get; set; }

    public MilestoneOrPhaseStatus Status { get; set; }

    public required string Comments { get; set; }
    public IEnumerable<ApprovedTeamDto>? ApprovedTeams { get; set; }
    public Project? Project { get; set; } 
  }
}
