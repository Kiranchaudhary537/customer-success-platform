using AutoMapper;
using Promact.CustomerSuccess.Platform.Entities;
using Promact.CustomerSuccess.Platform.Services.Dtos.StakeholderDtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Promact.CustomerSuccess.Platform.Services.Services
{
  public class StakeholderService : CrudAppService<Stakeholder, StakeholderDto, Guid, PagedAndSortedResultRequestDto, CreateStakeholderDto, UpdateStakeholderDto>, 
        IService
    {
        private readonly IMapper _mapper;
        public StakeholderService(IRepository<Stakeholder, Guid> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
             GetPolicyName = "read:stakeholder";
            GetListPolicyName = "read:stakeholder";
            CreatePolicyName = "create:stakeholder";
            UpdatePolicyName = "update:stakeholder";
            DeletePolicyName = "delete:stakeholder";
        }

        // get all by project id
        public async Task<List<StakeholderDto>> GetByProjectIdAsync(Guid projectId)
        {
            var stakeholders = await Repository.GetListAsync(x => x.ProjectId == projectId);
            return _mapper.Map<List<Stakeholder>, List<StakeholderDto>>(stakeholders);
        }
    }
}