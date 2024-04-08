namespace Promact.CustomerSuccess.Platform.Services.Dtos.ProjectOverviewDtos
{
  public class UpdateProjectOverviewDto
  {
    public Guid Id { get; set; }
    public required string Brief { get; set; }
    public required string Purpose { get; set; }
    public required string Goals { get; set; }
    public required string Objectives { get; set; }
    public required string Budget { get; set; }
  }
}