using AutoMapper;
using Promact.CustomerSuccess.Platform.Entities;
using Promact.CustomerSuccess.Platform.Services.Dtos.PhaseDtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Promact.CustomerSuccess.Platform.Services.Services
{
  public class PhaseMilestoneService : CrudAppService<PhaseMilestone,
      PhaseMilestoneDto, Guid, PagedAndSortedResultRequestDto, CreatePhaseMilestoneDto, UpdatePhaseMilestoneDto>,
        IService
    {
        private readonly IMapper _mapper;
        public PhaseMilestoneService(IRepository<PhaseMilestone, Guid> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
            GetPolicyName = "read:phase";
            GetListPolicyName = "read:phase";
            CreatePolicyName = "create:phase";
            UpdatePolicyName = "update:phase";
            DeletePolicyName = "delete:phase";
        }

        // get all phase milestones by project id
        public async Task<List<PhaseMilestoneDto>> GetByProjectIdAsync(Guid projectId)
        {
            var phaseMilestones = await Repository.GetListAsync(x => x.ProjectId == projectId);
            return _mapper.Map<List<PhaseMilestone>, List<PhaseMilestoneDto>>(phaseMilestones);
        }
    }
}