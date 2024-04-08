namespace Promact.CustomerSuccess.Platform.Services.Dtos.ApprovedTeamDtos
{
  public class UpdateApprovedTeamDto
  {
    public int NoOfResources { get; set; }
    public required string Role { get; set; }
    public int Availablity { get; set; }
    public int Duration { get; set; }
  }
}
