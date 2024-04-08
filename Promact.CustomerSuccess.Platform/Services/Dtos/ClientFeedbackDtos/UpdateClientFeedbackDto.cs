using Promact.CustomerSuccess.Platform.Entities;

namespace Promact.CustomerSuccess.Platform.Services.Dtos.ClientFeedbackDtos
{
  public class UpdateClientFeedbackDto
  {
    public DateTime FeedbackDate { get; set; }
    public FeedbackType FeedbackType { get; set; }
    public required string Details { get; set; }
    public virtual Project? Project { get; set; }
    public bool ActionTaken { get; set; }
    public DateTime? ClosureDate { get; set; }
  }
}
