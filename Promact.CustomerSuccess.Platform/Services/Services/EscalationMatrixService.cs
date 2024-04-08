using AutoMapper;
using Promact.CustomerSuccess.Platform.Entities;
using Promact.CustomerSuccess.Platform.Services.Dtos.EscalationMatrixDtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Promact.CustomerSuccess.Platform.Services.Services
{
    public class EscalationMatrixService : CrudAppService<EscalationMatrix,
        EscalationMatrixDto, Guid, PagedAndSortedResultRequestDto,
        CreateEscalationMatrixDto,
        UpdateEscalationMatrixDto>, IService
    {
        private readonly IMapper _mapper;
        public EscalationMatrixService(IRepository<EscalationMatrix, Guid> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
            GetPolicyName = "read:escalation-matrix";
            GetListPolicyName = "read:escalation-matrix";
            CreatePolicyName = "create:escalation-matrix";
            UpdatePolicyName = "update:escalation-matrix";
            DeletePolicyName = "delete:escalation-matrix";
        }

        // get all by project id
        public async Task<List<EscalationMatrixDto>> GetAllByProjectIdAsync(Guid projectId)
        {
            var escalationMatrices = await Repository.GetListAsync(x => x.ProjectId == projectId);
            return _mapper.Map<List<EscalationMatrix>, List<EscalationMatrixDto>>(escalationMatrices);
        }
    }
}
