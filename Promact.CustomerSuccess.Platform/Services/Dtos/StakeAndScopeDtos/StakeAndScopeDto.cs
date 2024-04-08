using Promact.CustomerSuccess.Platform.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Application.Dtos;

namespace Promact.CustomerSuccess.Platform.Services.Dtos.StakeAndScopeDtos
{
  public class StakeAndScopeDto:IEntityDto<Guid>
  {
        public Guid Id { get; set; }
        public required string Stake { get; set; }
        public required string Scope { get; set; }
        [ForeignKey("Project")]
        public Guid ProjectId { get; set; }
        public Project? Project { get; set; }
    }
}
