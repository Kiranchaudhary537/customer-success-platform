using AutoMapper;
using Promact.CustomerSuccess.Platform.Entities;
using Promact.CustomerSuccess.Platform.Services.Dtos.PhaseDtos;
using Promact.CustomerSuccess.Platform.Services.Dtos.ProjectBudgetDtos;
using Promact.CustomerSuccess.Platform.Services.Dtos.ProjectUpdateDtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Promact.CustomerSuccess.Platform.Services.Services
{
  public class ProjectUpdateService :
                CrudAppService<ProjectUpdate,
                ProjectUpdateDto,
                Guid,
                PagedAndSortedResultRequestDto,
                CreateProjectUpdateDto,
                UpdateProjectUpdateDto>,
                IService
    {
        private readonly IMapper _mapper;
        public ProjectUpdateService(IRepository<ProjectUpdate, Guid> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        // get all by project id
        public async Task<List<ProjectUpdateDto>> GetByProjectId(Guid projectId)
        {
            var result = await Repository.GetListAsync(x => x.ProjectId == projectId);
            return _mapper.Map<List<ProjectUpdate>, List<ProjectUpdateDto>>(result);
        }
    }
}
