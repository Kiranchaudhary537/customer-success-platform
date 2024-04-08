using Promact.CustomerSuccess.Platform.Entities;
using Promact.CustomerSuccess.Platform.Services.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Promact.CustomerSuccess.Platform.Services.Dtos.ProjectDtos;

namespace Promact.CustomerSuccess.Platform.Services.Services
{

  /// <summary>
  /// [Authorize]
  /// </summary>
  public class ProjectService :
        CrudAppService<Project,
            ProjectDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateProjectDto,
            UpdateProjectDto>,
        IProjectService
  {

    public ProjectService(IRepository<Project, Guid> projectRepository) :
        base(projectRepository)
    {
      GetPolicyName = "read:project";
      GetListPolicyName = "read:project";
      CreatePolicyName = "create:project";
      UpdatePolicyName = "update:project";
      DeletePolicyName = "delete:project";
    }
    }
}
