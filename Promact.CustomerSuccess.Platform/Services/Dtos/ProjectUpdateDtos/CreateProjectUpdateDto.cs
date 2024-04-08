namespace Promact.CustomerSuccess.Platform.Services.Dtos.ProjectUpdateDtos
{
  public class CreateProjectUpdateDto
  {
    public Guid ProjectId { get; set; }

    public DateTime Date { get; set; }

    public required string GeneralUpdates { get; set; }
  }
}
