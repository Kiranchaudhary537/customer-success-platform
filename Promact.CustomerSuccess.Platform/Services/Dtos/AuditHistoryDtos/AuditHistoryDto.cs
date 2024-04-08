using Promact.CustomerSuccess.Platform.Entities;
using Promact.CustomerSuccess.Platform.Services.Services;
using Volo.Abp.Application.Dtos;

namespace Promact.CustomerSuccess.Platform.Services.Dtos.AuditHistoryDtos
{
  public class AuditHistoryDto : IEntityDto<Guid>
  {
    public Guid Id { get; set; }
    public DateTime DateOfAudit { get; set; }
    public required string ReviewedBy { get; set; }
    public required string Status { get; set; }
    public required string Section { get; set; }
    public required string CommentQueries { get; set; }
    public required string ActionItem { get; set; }
    public Guid ProjectId { get; set; }
    public Project? Project { get; set; }
  }
}
