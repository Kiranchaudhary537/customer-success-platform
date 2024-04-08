using System.ComponentModel.DataAnnotations.Schema;
using Promact.CustomerSuccess.Platform.Entities;
using Volo.Abp.Application.Dtos;

namespace Promact.CustomerSuccess.Platform.Services.Dtos.ProjectResourceDtos
{
  public class ProjectResourceDto:IEntityDto<Guid>
  {
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public virtual Project? Project { get; set; }
    public double AllocationPercentage { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public required string Role { get; set; }
    public required string Name { get; set; }
    public string? Comment { get; set; }
  }
}
