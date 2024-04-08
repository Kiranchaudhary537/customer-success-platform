using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace Promact.CustomerSuccess.Platform.Entities
{
  public class ProjectOverview : Entity<Guid>
  {
    public required string Brief { get; set; }
    public required string Purpose { get; set; }
    public required string Goals { get; set; }
    public required string Objectives { get; set; }
    public required string Budget { get; set; }
    [ForeignKey("Project")]
    public Guid ProjectId { get; set; }
    public virtual Project? Project { get; set; }
  }
}
