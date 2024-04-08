namespace Promact.CustomerSuccess.Platform.Services.Dtos.StakeholderDtos
{
  public class CreateStakeholderDto
  {
    public required string Title { get; set; }
    public required string Name { get; set; }
    public required string ContactEmail { get; set; }
    public Guid ProjectId { get; set; }
  }
}
