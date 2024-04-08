namespace Promact.CustomerSuccess.Platform.Services.Dtos.PhaseDtos
{
  public class UpdatePhaseMilestoneDto
  { 
  public required string Title { get; set; }

  public DateTime StartDate { get; set; }

  public DateTime? CompletionDate { get; set; }

  public DateTime? ApprovalDate { get; set; }

  public MilestoneOrPhaseStatus Status { get; set; }

  public required string Comments { get; set; }
 
  }
}
