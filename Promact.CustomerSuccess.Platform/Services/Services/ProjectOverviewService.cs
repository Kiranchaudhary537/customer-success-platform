using AutoMapper;
using Promact.CustomerSuccess.Platform.Entities;
using Promact.CustomerSuccess.Platform.Services.Dtos.ProjectOverviewDtos;
using Promact.CustomerSuccess.Platform.Services.Dtos.RiskProfileDtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Promact.CustomerSuccess.Platform.Services.Services
{
  public class ProjectOverviewService : 
        CrudAppService<
            ProjectOverview, 
            RiskProfileDto, Guid, 
            PagedAndSortedResultRequestDto, 
            CreateProjectOverviewDto, 
            UpdateProjectOverviewDto>, IService
    {
        private readonly IMapper _mapper;
        public ProjectOverviewService(IRepository<ProjectOverview, Guid> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        // get all risk profiles by project id
        public async Task<List<ProjectOverviewDto>> GetAllByProjectIdAsync(Guid projectId)
        {
            var result = await Repository.GetListAsync(x => x.ProjectId == projectId);
            return _mapper.Map<List<ProjectOverview>, List<ProjectOverviewDto>>(result);
        }
    }
}
