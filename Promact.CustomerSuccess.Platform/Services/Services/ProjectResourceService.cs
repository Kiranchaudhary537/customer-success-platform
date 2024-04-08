using AutoMapper;
using Promact.CustomerSuccess.Platform.Entities;
using Promact.CustomerSuccess.Platform.Services.Dtos.PhaseDtos;
using Promact.CustomerSuccess.Platform.Services.Dtos.ProjectBudgetDtos;
using Promact.CustomerSuccess.Platform.Services.Dtos.ProjectResourceDtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Promact.CustomerSuccess.Platform.Services.Services
{
  public class ProjectResourceService :
       CrudAppService<ProjectResources,
            ProjectResourceDto,
           Guid,
           PagedAndSortedResultRequestDto,
           CreateProjectResourceDto,
           UpdateProjectResourceDto>,
       IService
    {
        private readonly IMapper _mapper;
        public ProjectResourceService(IRepository<ProjectResources, Guid> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        // get all by project id
        public async Task<List<ProjectResourceDto>> GetAllByProjectIdAsync(Guid projectId)
        {
            var result = await Repository.GetListAsync(x => x.ProjectId == projectId);
            return _mapper.Map<List<ProjectResources>, List<ProjectResourceDto>>(result);
        }
    }
}