namespace Promact.CustomerSuccess.Platform.Services.Dtos.ProjectBudgetDtos
{
  public class CreateProjectBudgetDto
  {
    public ProjectType Type { get; set; }
    public int? DurationInMonths { get; set; }
    public int? ContractDuration { get; set; }
    public int? BudgetedHours { get; set; }
    public required double BudgetedCost { get; set; }
    public required string Currency { get; set; }
    public Guid ProjectId { get; set; }
  }
}
