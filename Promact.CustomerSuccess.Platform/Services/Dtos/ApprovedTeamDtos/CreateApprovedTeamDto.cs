namespace Promact.CustomerSuccess.Platform.Services.Dtos.ApprovedTeamDtos
{
  public class CreateApprovedTeamDto
  {
    public int NoOfResources { get; set; }
    public string Role { get; set; }
    public int Availablity { get; set; }
    public int Duration { get; set; }
    public Guid PhaseMilestoneId { get; set; }
    public Guid ProjectId { get; set; }
  }
}
