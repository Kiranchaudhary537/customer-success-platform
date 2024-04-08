using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

namespace Promact.CustomerSuccess.Platform.Entities
{
  public class VersionHistory : AuditedAggregateRootWithUser<Guid, ApplicationUser>
  {
    public required string Version { get; set; }
    public required string Change { get; set; }
    public required string ChangeReason { get; set; }
    public required string CreatedBy { get; set; }
    public required DateTime RevisionDate { get; set; }
    public required DateTime ApprovalDate { get; set; }
    public required string ApprovedBy { get; set; }

    [ForeignKey("Project")]
    public Guid ProjectId { get; set; }
  }
}
