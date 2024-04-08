using Promact.CustomerSuccess.Platform.Entities;
using Volo.Abp.Application.Dtos;

namespace Promact.CustomerSuccess.Platform.Services.Dtos.VersionHistoriesDtos
{
  public class VersionHistoryDto : IEntityDto<Guid>
  {
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public int Version { get; set; }
    public string? Type { get; set; }
    public string? Change { get; set; }
    public string? ChangeReason { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? RevisionDate { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string? ApprovedBy { get; set; }

    public virtual Project Project { get; set; }
  }
}