using AutoMapper;
using Promact.CustomerSuccess.Platform.Entities;
using Promact.CustomerSuccess.Platform.Services.Dtos.EscalationMatrixDtos;
using Promact.CustomerSuccess.Platform.Services.Dtos.MeetingMinuteDtos;
using Promact.CustomerSuccess.Platform.Services.Services;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Promact.CustomerSuccess.Platform.Services
{
  public class MeetingMinuteService:
          CrudAppService<MeetingMinute,
         MeetingMinuteDto,
          Guid,
          PagedAndSortedResultRequestDto,
          CreateMeetingMinuteDto,
          UpdateMeetingMinuteDto>,
      IService
    {
        private readonly IMapper _mapper;
        public MeetingMinuteService(IRepository<MeetingMinute, Guid> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
            GetPolicyName = "read:meeting-minute";
            GetListPolicyName = "read:meeting-minute";
            CreatePolicyName = "create:meeting-minute";
            UpdatePolicyName = "update:meeting-minute";
            DeletePolicyName = "delete:meeting-minute";
        }
        public async Task<List<MeetingMinuteDto>> GetAllByProjectIdAsync(Guid projectId)
        {
            var escalationMatrices = await Repository.GetListAsync(x => x.ProjectId == projectId);
            return _mapper.Map<List<MeetingMinute>, List<MeetingMinuteDto>>(escalationMatrices);
        }
    }
}