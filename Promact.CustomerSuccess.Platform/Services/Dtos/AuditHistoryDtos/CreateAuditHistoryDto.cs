namespace Promact.CustomerSuccess.Platform.Services.Dtos.AuditHistoryDtos
{
  public class CreateAuditHistoryDto
  {
    public DateTime DateOfAudit { get; set; }
    public required string ReviewedBy { get; set; }
    public required string Status { get; set; }
    public required string Section { get; set; }
    public required string CommentQueries { get; set; }
    public required string ActionItem { get; set; }
    public Guid ProjectId { get; set; }
  }
}
