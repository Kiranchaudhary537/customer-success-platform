using Promact.CustomerSuccess.Platform.Entities;
using Promact.CustomerSuccess.Platform.Services.Services;
using Volo.Abp.Application.Dtos;

namespace Promact.CustomerSuccess.Platform.Services.Dtos.RiskProfileDtos
{
  public class RiskProfileDto:IEntityDto<Guid>
  {
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public RiskType RiskType { get; set; }
    public RiskType Description { get; set; }
    public required string Severity { get; set; }
    public RiskImpact Impact { get; set; }
    public string Status { get; set; }
    public DateTime ClosureDate { get; set; }
    public virtual ICollection<RemediationStep>? RemediationSteps { get; set; }
    public virtual Project? Project { get; set; }
  }
}
