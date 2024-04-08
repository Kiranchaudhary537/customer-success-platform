using Promact.CustomerSuccess.Platform.Entities;
using Volo.Abp.Application.Dtos;

namespace Promact.CustomerSuccess.Platform.Services.Dtos.ProjectOverviewDtos
{
  public class ProjectOverviewDto:IEntityDto<Guid>
  {
    public Guid Id { get; set; }
    public required string Brief { get; set; }
    public required string Purpose { get; set; }
    public required string Goals { get; set; }
    public required string Objectives { get; set; }
    public required string Budget { get; set; }
    public Guid ProjectId { get; set; }
    public virtual Project? Project { get; set; }
  }
}
