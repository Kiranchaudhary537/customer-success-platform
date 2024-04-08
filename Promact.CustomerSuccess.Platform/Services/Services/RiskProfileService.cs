using AutoMapper;
using Promact.CustomerSuccess.Platform.Entities;
using Promact.CustomerSuccess.Platform.Services.Dtos.RiskProfileDtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Promact.CustomerSuccess.Platform.Services.Services
{
  public class RiskProfileService : 
        CrudAppService<RiskProfile, 
            RiskProfileDto, Guid, PagedAndSortedResultRequestDto, CreateRiskProfileDto, UpdateRiskProfileDto>, 
        IService
    {
        private readonly IMapper _mapper;
        public RiskProfileService(IRepository<RiskProfile, Guid> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
             GetPolicyName = "read:risk-profile";
            GetListPolicyName = "read:risk-profile";
            CreatePolicyName = "create:risk-profile";
            UpdatePolicyName = "update:risk-profile";
            DeletePolicyName = "delete:risk-profile";
        }

        // get all by project id
        public async Task<List<RiskProfileDto>> GetAllByProjectIdAsync(Guid projectId)
        {
            var riskProfiles = await Repository.GetListAsync(x => x.ProjectId == projectId);
            return _mapper.Map<List<RiskProfile>, List<RiskProfileDto>>(riskProfiles);
        }
    }
}
