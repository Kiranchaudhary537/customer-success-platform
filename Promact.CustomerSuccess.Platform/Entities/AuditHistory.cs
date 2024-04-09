using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

namespace Promact.CustomerSuccess.Platform.Entities
{
  public class AuditHistory : AuditedAggregateRootWithUser<Guid, ApplicationUser>
    {
    public DateTime DateOfAudit { get; set; }
    public required string ReviewedBy { get; set; }
    public required string Status { get; set; }
    public required string Section { get; set; }
    public required string CommentQueries { get; set; }
    public required string ActionItem { get; set; }

    [ForeignKey("Project")]
    public Guid ProjectId { get; set; }
    public virtual Project? Project { get; set; }
  }
}
