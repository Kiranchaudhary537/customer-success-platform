using AutoMapper;
using Promact.CustomerSuccess.Platform.Entities;
using Promact.CustomerSuccess.Platform.Services.Dtos.ApprovedTeamDtos;
using Promact.CustomerSuccess.Platform.Services.Dtos.AuditHistoryDtos;
using Promact.CustomerSuccess.Platform.Services.Dtos.ClientFeedbackDtos;
using Promact.CustomerSuccess.Platform.Services.Dtos.EscalationMatrixDtos;
using Promact.CustomerSuccess.Platform.Services.Dtos.MeetingMinuteDtos;
using Promact.CustomerSuccess.Platform.Services.Dtos.PhaseDtos;
using Promact.CustomerSuccess.Platform.Services.Dtos.ProjectBudgetDtos;
using Promact.CustomerSuccess.Platform.Services.Dtos.ProjectDtos;
using Promact.CustomerSuccess.Platform.Services.Dtos.ProjectOverviewDtos;
using Promact.CustomerSuccess.Platform.Services.Dtos.ProjectResourceDtos;
using Promact.CustomerSuccess.Platform.Services.Dtos.ProjectUpdateDtos;
using Promact.CustomerSuccess.Platform.Services.Dtos.RiskProfileDtos;
using Promact.CustomerSuccess.Platform.Services.Dtos.SprintDtos;
using Promact.CustomerSuccess.Platform.Services.Dtos.StakeAndScopeDtos;
using Promact.CustomerSuccess.Platform.Services.Dtos.StakeholderDtos;
using Promact.CustomerSuccess.Platform.Services.Dtos.VersionHistoriesDtos;

namespace Promact.CustomerSuccess.Platform.ObjectMapping;

public class PlatformAutoMapperProfile : Profile
{
    public PlatformAutoMapperProfile()
    {
    CreateMap<CreateProjectDto, Project>();
    CreateMap<UpdateProjectDto, Project>();
    CreateMap<Project, ProjectDto>().ReverseMap();

    CreateMap<CreateClientFeedbackDto, ClientFeedback>();
    CreateMap<UpdateClientFeedbackDto, ClientFeedback>();
    CreateMap<ClientFeedback, ClientFeedbackDto>().ReverseMap();

    CreateMap<CreateProjectResourceDto, ProjectResources>();
    CreateMap<UpdateProjectResourceDto, ProjectResources>();
    CreateMap<ProjectResources, ProjectResourceDto>().ReverseMap();

    CreateMap<CreateProjectUpdateDto, ProjectUpdate>();
    CreateMap<UpdateProjectUpdateDto, ProjectUpdate>();
    CreateMap<ProjectUpdate, ProjectUpdateDto>().ReverseMap();

    CreateMap<CreateMeetingMinuteDto, MeetingMinute>();
    CreateMap<UpdateMeetingMinuteDto, MeetingMinute>();
    CreateMap<MeetingMinute, MeetingMinuteDto>().ReverseMap();

    CreateMap<CreateApprovedTeamDto, ApprovedTeam>();
    CreateMap<UpdateApprovedTeamDto, ApprovedTeam>();
    CreateMap<ApprovedTeam, ApprovedTeamDto>().ReverseMap();

    CreateMap<CreateProjectBudgetDto, ProjectBudget>();
    CreateMap<UpdateProjectBudgetDto, ProjectBudget>();
    CreateMap<ProjectBudget, ProjectBudgetDto>().ReverseMap();

    CreateMap<CreateAuditHistoryDto, AuditHistory>();
    CreateMap<UpdateAuditHistoryDto, AuditHistory>();
    CreateMap<AuditHistory, AuditHistoryDto>().ReverseMap();

    CreateMap<CreateVersionHistoryDto, VersionHistory>();
    CreateMap<UpdateVersionHistoryDto, VersionHistory>();
    CreateMap<VersionHistory, VersionHistoryDto>().ReverseMap();

    CreateMap<CreateStakeholderDto, Stakeholder>();
    CreateMap<UpdateStakeholderDto, Stakeholder>();
    CreateMap<Stakeholder, StakeholderDto>().ReverseMap();

    CreateMap<CreateRiskProfileDto, RiskProfile>();
    CreateMap<UpdateRiskProfileDto, RiskProfile>();
    CreateMap<RiskProfile, RiskProfileDto>().ReverseMap();


    CreateMap<CreateAuditHistoryDto, AuditHistory>();
    CreateMap<UpdateAuditHistoryDto, AuditHistory>();
    CreateMap<AuditHistory, AuditHistoryDto>().ReverseMap();


    CreateMap<CreateVersionHistoryDto, VersionHistory>();
    CreateMap<UpdateVersionHistoryDto, VersionHistory>();
    CreateMap<VersionHistory, VersionHistoryDto>().ReverseMap();


    CreateMap<CreateStakeholderDto, Stakeholder>();
    CreateMap<UpdateStakeholderDto, Stakeholder>();
    CreateMap<Stakeholder, StakeholderDto>().ReverseMap();


    CreateMap<CreateEscalationMatrixDto, EscalationMatrix>();
    CreateMap<UpdateEscalationMatrixDto, EscalationMatrix>();
    CreateMap<EscalationMatrix, EscalationMatrixDto>().ReverseMap();

    CreateMap<CreatePhaseMilestoneDto, PhaseMilestone>();
    CreateMap<UpdatePhaseMilestoneDto, PhaseMilestone>();
    CreateMap<PhaseMilestone, PhaseMilestoneDto>().ReverseMap();

    CreateMap<CreateSprintDto, Sprint>();
    CreateMap<UpdateSprintDto, Sprint>();
    CreateMap<Sprint, SprintDto>().ReverseMap();

    CreateMap<CreateProjectOverviewDto, ProjectOverview>();
    CreateMap<UpdateProjectOverviewDto, ProjectOverview>();
    CreateMap<ProjectOverview,ProjectOverviewDto >().ReverseMap();

    CreateMap<CreateStakeAndScopeDto, StakeAndScope>();
    CreateMap<UpdateStakeAndScopeDto, StakeAndScope>();
    CreateMap<StakeAndScope, StakeAndScopeDto>().ReverseMap();

  }
}
