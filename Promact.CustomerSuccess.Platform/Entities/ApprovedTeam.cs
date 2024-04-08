using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

namespace Promact.CustomerSuccess.Platform.Entities
{
  public class ApprovedTeam:AuditedEntity<Guid>
  {
    public int NumberOfResources { get; set; }
    public required string Role { get; set; }
    public int AvailabilityPercentage { get; set; }
    public int Duration { get; set; }

    [ForeignKey("PhaseMilestone")]
    public Guid PhaseMilestoneId { get; set; }
    public virtual PhaseMilestone? PhaseMilestone { get; set; }

    [ForeignKey("Project")]
    public Guid ProjectId { get; set; }

    public virtual Project? Project { get; set; }
  }
}
