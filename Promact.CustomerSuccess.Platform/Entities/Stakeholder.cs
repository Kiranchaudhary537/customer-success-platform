using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

namespace Promact.CustomerSuccess.Platform.Entities
{
  public class Stakeholder: AuditedEntity<Guid>
  {
    public StakeholderTitle Title { get; set; }
    public required string Name { get; set; }
    public required string ContactEmail { get; set; }

    [ForeignKey(nameof(Project))]
    public Guid ProjectId { get; set; }
    public virtual Project? Project { get; set; }
  }
}
