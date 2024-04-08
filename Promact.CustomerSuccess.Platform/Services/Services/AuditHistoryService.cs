using AutoMapper;
using Promact.CustomerSuccess.Platform.Entities;
using Promact.CustomerSuccess.Platform.Services.Dtos.ApprovedTeamDtos;
using Promact.CustomerSuccess.Platform.Services.Dtos.AuditHistoryDtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Promact.CustomerSuccess.Platform.Services.Services
{
  public class AuditHistoryService : CrudAppService<AuditHistory,
            AuditHistoryDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateAuditHistoryDto,
            UpdateAuditHistoryDto>,
        IService
  {
    private readonly IMapper _mapper;
        private readonly EmailService _emailService;
        public AuditHistoryService(IRepository<AuditHistory, Guid> repository, EmailService emailService, Mapper mapper) :
        base(repository)
        {
          _mapper = mapper;
          _emailService = emailService;
          GetPolicyName = "read:audit-history";
          GetListPolicyName ="read:audit-history";
          CreatePolicyName = "create:audit-history";
          UpdatePolicyName = "update:audit-history";
          DeletePolicyName = "delete:audit-history";
        }

        public async override Task<AuditHistoryDto> CreateAsync(CreateAuditHistoryDto input)
        {

            var entity = _mapper.Map<CreateAuditHistoryDto, AuditHistory>(input);
            await Repository.InsertAsync(entity, autoSave: true);
            await _emailService.sendAuditHistoryNotification(entity, "create", entity.ProjectId);
            return _mapper.Map<AuditHistoryDto>(entity);
        }

        public async override Task<AuditHistoryDto> UpdateAsync(Guid id, UpdateAuditHistoryDto input)
        {

            var entity = await Repository.GetAsync(id);
            if(entity == null)
            {
                throw new EntityNotFoundException();
            }
            _mapper.Map(input, entity);
            await _emailService.sendAuditHistoryNotification(entity, "update", entity.ProjectId);
            await Repository.UpdateAsync(entity, autoSave: true);
            return _mapper.Map<AuditHistoryDto>(entity);
            
        }


        public async Task<List<AuditHistoryDto>> GetAllByProjectIdAsync(Guid projectId)
    {
      var result = await Repository.GetListAsync(x => x.ProjectId == projectId);
      return _mapper.Map<List<AuditHistory>, List<AuditHistoryDto>>(result);
    }
  }
}

