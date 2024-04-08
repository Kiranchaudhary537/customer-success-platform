namespace Promact.CustomerSuccess.Platform.Services.Dtos.MeetingMinuteDtos
{
  public class UpdateMeetingMinuteDto
  {
    public required DateTime MeetingDate { get; set; }
    public required string MoMLink { get; set; }
    public required string Comments { get; set; }
  }
}
