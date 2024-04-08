using Promact.CustomerSuccess.Platform.Entities;
using Volo.Abp.Application.Dtos;

namespace Promact.CustomerSuccess.Platform.Services.Dtos.StakeholderDtos
{
  public class StakeholderDto : IEntityDto<Guid>
  {
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public  required string Name { get; set; }
    public required string ContactEmail { get; set; }
    public Guid ProjectId { get; set; }
    public virtual Project Project { get; set; }
  }
}
