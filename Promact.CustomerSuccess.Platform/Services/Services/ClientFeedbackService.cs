using AutoMapper;
using Promact.CustomerSuccess.Platform.Entities;
using Promact.CustomerSuccess.Platform.Services.Dtos.AuditHistoryDtos;
using Promact.CustomerSuccess.Platform.Services.Dtos.ClientFeedbackDtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Promact.CustomerSuccess.Platform.Services.Services
{
  public class ClientFeedbackService : CrudAppService<ClientFeedback,
            ClientFeedbackDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateClientFeedbackDto,
            UpdateClientFeedbackDto>,
        IService
    {
        private readonly IMapper _mapper;
        public ClientFeedbackService(IRepository<ClientFeedback, Guid> repository, Mapper mapper) :
            base(repository)
        {
            _mapper = mapper;
            GetPolicyName = "read:client-feedback";
            GetListPolicyName = "read:client-feedback";
            CreatePolicyName = "create:client-feedback";
            UpdatePolicyName = "update:client-feedback";
            DeletePolicyName = "delete:client-feedback";
        }

        public async Task<List<ClientFeedbackDto>> GetAllByProjectIdAsync(Guid projectId)
        {
            var result = await Repository.GetListAsync(x => x.ProjectId == projectId);
            return _mapper.Map<List<ClientFeedback>, List<ClientFeedbackDto>>(result);
        }
    }
}


