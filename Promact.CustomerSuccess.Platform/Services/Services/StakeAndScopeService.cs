using AutoMapper;
using Promact.CustomerSuccess.Platform.Entities;
using Promact.CustomerSuccess.Platform.Services.Dtos.StakeAndScopeDtos;
using Promact.CustomerSuccess.Platform.Services.Dtos.VersionHistoriesDtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Promact.CustomerSuccess.Platform.Services.Services
{
  public class StakeAndScopeService : 
        CrudAppService<StakeAndScope,
                               StakeAndScopeDto,
                               Guid,
                               PagedAndSortedResultRequestDto,
                               CreateStakeAndScopeDto,
                               UpdateStakeAndScopeDto>,
                               IService
    {
        private readonly IMapper _mapper;
        public StakeAndScopeService(IRepository<StakeAndScope, Guid> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }
        // get by project id
        public async Task<List<StakeAndScopeDto>> GetAllByProjectIdAsync(Guid projectId)
        {
            var result = await Repository.GetListAsync(x => x.ProjectId == projectId);
            return _mapper.Map<List<StakeAndScope>, List<StakeAndScopeDto>>(result);
        }
    }
}
