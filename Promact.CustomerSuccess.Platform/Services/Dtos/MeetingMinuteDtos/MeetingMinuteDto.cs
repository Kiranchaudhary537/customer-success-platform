using System.ComponentModel.DataAnnotations.Schema;
using Promact.CustomerSuccess.Platform.Entities;
using Volo.Abp.Application.Dtos;

namespace Promact.CustomerSuccess.Platform.Services.Dtos.MeetingMinuteDtos
{
  public class MeetingMinuteDto:IEntityDto<Guid>
  {
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public required DateTime MeetingDate { get; set; }
    public required string MoMLink { get; set; }
    public required string Comments { get; set; }
    public virtual Project? Project { get; set; }
  }
}
