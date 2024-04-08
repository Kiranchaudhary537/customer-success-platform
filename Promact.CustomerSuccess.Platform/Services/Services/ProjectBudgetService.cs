using AutoMapper;
using Promact.CustomerSuccess.Platform.Entities;
using Promact.CustomerSuccess.Platform.Services.Dtos.ProjectBudgetDtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Promact.CustomerSuccess.Platform.Services.Services
{
  public class ProjectBudgetService : CrudAppService<ProjectBudget, ProjectBudgetDto, Guid, PagedAndSortedResultRequestDto, CreateProjectBudgetDto, UpdateProjectBudgetDto>,
         IService
    {
        private readonly IMapper _mapper;
        public ProjectBudgetService(IRepository<ProjectBudget, Guid> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        // get all by project id
        public async Task<List<ProjectBudgetDto>> GetByProjectId(Guid projectId)
        {
            var projectBudgets = await Repository.GetListAsync(x => x.ProjectId == projectId);
            return _mapper.Map<List<ProjectBudgetDto>>(projectBudgets);
        }
    }
}