using Promact.CustomerSuccess.Platform.Entities;
using Volo.Abp.Application.Services;

namespace Promact.CustomerSuccess.Platform.Services.Services
{
    public class PdfGeneratorService: ApplicationService
    {
        private readonly ApprovedTeamService _approvedTeam;
        private readonly PhaseMilestoneService _phase;
        private readonly ClientFeedbackService _clientFeedback;
        private readonly EscalationMatrixService _escalationMatrix;
        private readonly AuditHistoryService _auditHistory;
        private readonly MeetingMinuteService _meetingMinute;
        private readonly ProjectOverviewService _overview;
        private readonly ProjectBudgetService _projectBudget;
        private readonly ProjectResourceService _projectResources;
        private readonly ProjectUpdateService _projectUpdate;
        private readonly RiskProfileService _riskProfile;
        private readonly SprintService _sprint;
        private readonly StakeAndScopeService _stakeAndScopeService;
        private readonly StakeholderService _stakeholder;
        private readonly ProjectService _project;

        public PdfGeneratorService(
            ProjectService project,
            ProjectBudgetService projectBudget,
            ProjectResourceService projectResources,
            SprintService sprintService,
            StakeholderService stakeholder,
            ClientFeedbackService clientFeedback,
            RiskProfileService riskProfile,
            EscalationMatrixService escalationMatrix,
            AuditHistoryService auditHistory,
            ApprovedTeamService approvedTeam,
            PhaseMilestoneService phase,
            MeetingMinuteService meetingMinute,
            StakeAndScopeService stakeAndScope,
            ProjectOverviewService overview)
        {
            _phase = phase;
            _approvedTeam = approvedTeam;
            _overview = overview;
            _stakeAndScopeService = stakeAndScope;
            _auditHistory = auditHistory;
            _escalationMatrix = escalationMatrix;
            _riskProfile = riskProfile;
            _sprint = sprintService;
            _stakeholder = stakeholder;
            _clientFeedback = clientFeedback;
            _projectResources = projectResources;
            _projectBudget = projectBudget;
            _project = project;
            _meetingMinute = meetingMinute;
        }
        public async Task<byte[]> GetByIdAsync(Guid id)
        {
            var renderer = new ChromePdfRenderer();

            var project = await _project.GetAsync(id);


            var projectApprovedTeams = await _approvedTeam.GetAllByProjectIdAsync(id);
   
            var phase = await _phase.GetAllByProjectIdAsync(id);
          
            var projectclientfeedback = await _clientFeedback.GetAllByProjectIdAsync(id);

            var auditHistories = await _auditHistory.GetAllByProjectIdAsync(id);

            var escalationMatrices = await _escalationMatrix.GetAllByProjectIdAsync(id);

            var meetingMinutes = await _meetingMinute.GetAllByProjectIdAsync(id);

            var overview = await _overview.GetAllByProjectIdAsync(id);
            
            var stakeAndScopes = await _stakeAndScopeService.GetAllByProjectIdAsync(id);
            
            var riskProfiles = await _riskProfile.GetAllByProjectIdAsync(id);
            

            var projectResource = await _projectResources.GetAllByProjectIdAsync(id);
           
            //var allProjectUpdate = await _projectUpdate.GetAllAsync();
            //var projectUpdates = allProjectUpdate.Where(item => item.ProjectId == id).ToList();


            string html = "<h1> Project Details </h1>";
            html += "<br>";
            html += "<table border=\"1\" style=\"border-collapse: collapse; width: 100%;\">";
            html += "<tr><th>Project Name</th>" +
                "<th>Description</th>" +
                "<th>Member</th><" +
                "th>Status</th>" +
                "<th>Project Manager</th></tr>";
                html += "<tr>";
                html += "<td>" + project.Name + "</td>";
                html += "<td>" + project.Description + "</td>";
                html += "<td>" + project.Member + "</td>";
                html += "<td>" + project.Status + "</td>";
                html += "<td>" + project.ProjectManager + "</td>";
                html += "</tr>";
            
            html += "</table>";
            html += "<br>";

            html += "<h4>Project Overview</h4>";
            html += "<table border=\"1\" style=\"border-collapse: collapse; width: 100%;\">";
            html += "<tr><th>Project Brief</th><th>Project Goals</th><th>Project Objectives</th><th>Project Purpose</th></tr>";
            foreach (var item in overview)
            {
                html += "<tr>";
                html += "<td>" + item.Brief + "</td>";
                html += "<td>" + item.Goals + "</td>";
                html += "<td>" + item.Objectives + "</td>";
                html += "<td>" + item.Purpose + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            html += "<br>";
            html += "<h4>Stake and scope</h4>";
            html += "<br>";
            html += "<table border=\"1\" style=\"border-collapse: collapse; width: 100%;\">";
            html += "<tr><th>Project Stake</th><th>Project Scope</th></tr>";
            foreach (var item in stakeAndScopes)
            {
                html += "<tr>";
                html += "<td>" + item.Stake + "</td>";
                html += "<td>" + item.Scope + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            html += "<br>";

            html += "<h4>Approved Team</h4>";
            html += "<table border=\"1\" style=\"border-collapse: collapse; width: 100%;\">";
            html += "<tr><th>Role</th><th>Number of Resources</th><th>Duration</th><th>AvailabilityPercentage</th></tr>";
            foreach (var item in projectApprovedTeams)
            {
                html += "<tr>";
                html += "<td>" + item.Role + "</td>";
                html += "<td>" + item.NoOfResources + "</td>";
                html += "<td>" + item.Duration + "</td>";
                html += "<td>" + item.Availablity + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            html += "<br>";
            html += "<h4>Stake and scope</h4>";
            html += "<br>";
            html += "<table border=\"1\" style=\"border-collapse: collapse; width: 100%;\">";
            html += "<tr><th>Title</th><th>Status</th><th>Approval Date</th>" +
                "<th>Completion Date</th><th>Comments</th></tr>";
            foreach (var item in phase)
            {
                html += "<tr>";
                html += "<td>" + item.Title + "</td>";
                html += "<td>" + item.Status + "</td>";
                html += "<td>" + item.ApprovalDate + "</td>";
                html += "<td>" + item.CompletionDate + "</td>";
                html += "<td>" + item.Comments + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            html += "<br>";

            html += "<h4>Audit History</h4>";
            html += "<table border=\"1\" style=\"border-collapse: collapse; width: 100%;\">";
            html += "<tr><th>Date of Audit</th><th>Reviewed By</th><th>Status</th><th>Reviewed Section</th><th>Comment Queries</th><th>Action Item</th></tr>";
            foreach (var item in auditHistories)
            {
                html += "<tr>";
                html += "<td>" + item.DateOfAudit + "</td>";
                html += "<td>" + item.ReviewedBy + "</td>";
                html += "<td>" + item.Status + "</td>";
                html += "<td>" + item.Section + "</td>";
                html += "<td>" + item.CommentQueries + "</td>";
                html += "<td>" + item.ActionItem + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            html += "<br>";

            html += "<h4>Escalation Matrix</h4>";
            html += "<br>";
            html += "<table border=\"1\" style=\"border-collapse: collapse; width: 100%;\">";
            html += "<tr><th>Escalation Level</th><th>Type</th></tr>";
            foreach (var item in escalationMatrices)
            {
                html += "<tr>";
                html += "<td>" + item.Level + "</td>";
                html += "<td>" + item.EscalationType + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            html += "<br>";

            html += "<h4>Risk Profile</h4>";
            html += "<table border=\"1\" style=\"border-collapse: collapse; width: 100%;\">";
            html += "<tr><th>Risk Type</th><th>Severity</th><th>Impact</th></tr>";

            foreach (var item in riskProfiles)
            {
                html += "<tr>";
                html += "<td>" + item.RiskType + "</td>";
                html += "<td>" + item.Severity + "</td>";
                html += "<td>" + item.Impact + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            html += "<br>";

            //html += "<h4>Project Udpate</h4>";
            //html += "<table border=\"1\" style=\"border-collapse: collapse; width: 100%;\">";
            //html += "<tr><th>Date</th><th>GeneralUpdates</th><th>Impact</th></tr>";
            //foreach (var item in projectUpdates)
            //{
            //    html += "<tr>";
            //    html += "<td>" + item.Date + "</td>";
            //    html += "<td>" + item.GeneralUpdates + "</td>";
            //    html += "</tr>";
            //}

            html += "<h4>Project Resources</h4>";
            html += "<table border=\"1\" style=\"border-collapse: collapse; width: 100%;\">";
            html += "<tr><th>Allocation Percentage</th><th>Start Date</th><th>End Date</th><th>Role</th><th>Name</th></tr>";
            foreach (var item in projectResource)
            {
                html += "<tr>";
                html += "<td>" + item.AllocationPercentage + "</td>";
                html += "<td>" + item.Start + "</td>";
                html += "<td>" + item.End + "</td>";
                html += "<td>" + item.Role + "</td>";
                html += "<td>" + item.Name + "</td>";
                html += "</tr>";
            }

            var document = await renderer.RenderHtmlAsPdfAsync(html);

            // Convert the PDF document to a byte array
            byte[] documentBytes = document.BinaryData;
            var memoryStream = new MemoryStream(documentBytes);
            return memoryStream.ToArray();


        }
    }
}