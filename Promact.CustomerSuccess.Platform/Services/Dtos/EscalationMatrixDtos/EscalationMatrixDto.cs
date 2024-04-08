using System.ComponentModel.DataAnnotations.Schema;
using Promact.CustomerSuccess.Platform.Entities;
using Volo.Abp.Application.Dtos;

namespace Promact.CustomerSuccess.Platform.Services.Dtos.EscalationMatrixDtos
{
  public class EscalationMatrixDto:IEntityDto<Guid>
  {
    public Guid Id { get; set; }
    public EscalationMatrixLevels Level { get; set; }
    public EscalationType EscalationType { get; set; }
    public required Guid ProjectId { get; set; }
    public virtual Project? Project { get; set; }
  }
}
