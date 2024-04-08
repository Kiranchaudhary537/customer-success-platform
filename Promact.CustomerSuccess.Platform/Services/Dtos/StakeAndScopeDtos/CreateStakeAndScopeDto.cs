using System.ComponentModel.DataAnnotations.Schema;

namespace Promact.CustomerSuccess.Platform.Services.Dtos.StakeAndScopeDtos
{
  public class CreateStakeAndScopeDto
  {
        public required string Stake { get; set; }
        public required string Scope { get; set; }
        [ForeignKey("Project")]
        public Guid ProjectId { get; set; }
    }
}
