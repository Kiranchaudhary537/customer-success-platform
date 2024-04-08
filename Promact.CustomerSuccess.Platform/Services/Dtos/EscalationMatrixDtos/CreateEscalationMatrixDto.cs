namespace Promact.CustomerSuccess.Platform.Services.Dtos.EscalationMatrixDtos
{
  public class CreateEscalationMatrixDto
  {
    public EscalationMatrixLevels Level { get; set; }
    public EscalationType EscalationType { get; set; }
    public required Guid ProjectId { get; set; }
  }
}
