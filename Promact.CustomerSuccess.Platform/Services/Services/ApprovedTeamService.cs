using AutoMapper;
using Promact.CustomerSuccess.Platform.Entities;
using Promact.CustomerSuccess.Platform.Services.Dtos.ApprovedTeamDtos;
using Promact.CustomerSuccess.Platform.Services.Dtos.SprintDtos;
using Promact.CustomerSuccess.Platform.Services.Dtos.StakeholderDtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Promact.CustomerSuccess.Platform.Services.Services
{
  public class ApprovedTeamService : CrudAppService<ApprovedTeam,
            ApprovedTeamDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateApprovedTeamDto,
            UpdateApprovedTeamDto>,
        IService
  {
    private readonly IMapper _mapper;
    public ApprovedTeamService(IRepository<ApprovedTeam, Guid> repository,Mapper mapper) :
        base(repository)
    {
      _mapper = mapper;
    }

    // get all by project id
    public async Task<List<ApprovedTeamDto>> GetByProjectIdAsync(Guid projectId)
    {
      var result = await Repository.GetListAsync(x => x.ProjectId == projectId);
      return _mapper.Map<List<ApprovedTeam>, List<ApprovedTeamDto>>(result);
    }
        // get by phase milestone id
    public async Task<ApprovedTeamDto> GetByPhaseMilestoneIdAsync(Guid phaseMilestoneId)
    {
            var sprint = await Repository.FirstOrDefaultAsync(x => x.PhaseMilestoneId == phaseMilestoneId);
            return _mapper.Map<ApprovedTeamDto>(sprint);
    }
    
   }
}
