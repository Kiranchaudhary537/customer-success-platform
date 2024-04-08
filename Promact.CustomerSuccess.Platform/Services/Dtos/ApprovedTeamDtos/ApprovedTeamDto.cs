using Promact.CustomerSuccess.Platform.Entities;
using Promact.CustomerSuccess.Platform.Services.Dtos.PhaseDtos;
using Promact.CustomerSuccess.Platform.Services.Services;
using Volo.Abp.Application.Dtos;

namespace Promact.CustomerSuccess.Platform.Services.Dtos.ApprovedTeamDtos
{
  public class ApprovedTeamDto : IEntityDto<Guid>
  {
    public Guid Id { get; set; }
    public int NoOfResources { get; set; }
    public required string Role { get; set; }
    public int Availablity { get; set; }
    public int Duration { get; set; }
    public Guid ProjectId { get; set; }
    public Project? Project { get; set; }
    public Guid MilestoneOrPhaseId { get; set; }
    public PhaseMilestone? PhaseMilestone { get; set; }   
  }
}
