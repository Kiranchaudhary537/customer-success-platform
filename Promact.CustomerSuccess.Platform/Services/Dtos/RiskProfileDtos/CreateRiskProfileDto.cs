namespace Promact.CustomerSuccess.Platform.Services.Dtos.RiskProfileDtos
{
  public class CreateRiskProfileDto
  {
    public Guid ProjectId { get; set; }
    public RiskType RiskType { get; set; }
    public RiskType Description { get; set; }
    public required string Severity { get; set; }
    public RiskImpact Impact { get; set; }
    public required string Status { get; set; }
    public required DateTime ClosureDate { get; set; }
  }
}
