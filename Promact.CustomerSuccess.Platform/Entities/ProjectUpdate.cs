using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

namespace Promact.CustomerSuccess.Platform.Entities
{
  public class ProjectUpdate:AuditedEntity<Guid>
  {
    [ForeignKey(nameof(Project))]
    public Guid ProjectId { get; set; }

    public DateTime Date { get; set; }

    public string? GeneralUpdates { get; set; }
    public virtual Project? Project { get; set; }
  }
}
