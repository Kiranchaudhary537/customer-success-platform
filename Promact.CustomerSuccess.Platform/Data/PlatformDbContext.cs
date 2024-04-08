using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Promact.CustomerSuccess.Platform.Entities;
using System.Reflection.Emit;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Promact.CustomerSuccess.Platform.Data;

public class PlatformDbContext : AbpDbContext<PlatformDbContext>
{
    public PlatformDbContext(DbContextOptions<PlatformDbContext> options)
        : base(options)
    {
    }

    public DbSet<Project> Projects { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<DocumentVersion> DocumentVersions { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<ClientFeedback> ClientFeedbacks { get; set; }
    public DbSet<ProjectBudget> ProjectBudgets { get; set; }
    public DbSet<PhaseMilestone> PhaseMilestones { get; set; }
    public DbSet<ProjectResources> ProjectResources { get; set; }
    public DbSet<RiskProfile> RiskProfiles { get; set; }
    public DbSet<MeetingMinute> MeetingMinutes { get; set; }
    public DbSet<EscalationMatrix> EscalationMatrices { get; set; }
    public DbSet<Sprint> Sprints { get; set; }
    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<AuditHistory> AuditHistory { get; set; }
    public DbSet<ApprovedTeam> ApprovedTeams { get; set; }
    public DbSet<ProjectUpdate> ProjectUpdates { get; set; }
    public DbSet<ApplicationUser> ApplicationUser { get; set; }
    public DbSet<VersionHistory> VersionHistories { get; set; }
    public DbSet<Stakeholder> Stakeholders { get; set; }
    public DbSet<RemediationStep> RemediationSteps { get; set; }
    public DbSet<ProjectOverview> ProjectOverviews { get; set; }
    public DbSet<StakeAndScope> StakeAndScopes { get; set; }

  protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own entities here */
        builder.Entity<DocumentVersion>(entity =>
        {                        
            entity.ConfigureByConvention();
        });
        builder.Entity<EscalationMatrix>(EscalationMatrix =>
        {            
            EscalationMatrix.ConfigureByConvention();
        });
        builder.Entity<MeetingMinute>(MeetingMinute =>
        {            
            MeetingMinute.ConfigureByConvention();
        });
        builder.Entity<Organization>(Organization =>
        {
            Organization.ConfigureByConvention();
        });
        builder.Entity<Project>(Project =>
        {
          Project.ConfigureByConvention();
        });
        builder.Entity<ProjectBudget>(ProjectBudget =>
        {
            ProjectBudget.ConfigureByConvention();
        });
        builder.Entity<ProjectResources>(ProjectResources =>
        {
            ProjectResources.ConfigureByConvention();
        });
        builder.Entity<RiskProfile>(RiskProfile =>
        {
            RiskProfile.ConfigureByConvention();
        });
        builder.Entity<Sprint>(Sprint =>
        {
            Sprint.ConfigureByConvention();
        });
        builder.Entity<PhaseMilestone>(PhaseMilestone =>
        {
            PhaseMilestone.ConfigureByConvention();
        });
        builder.Entity<ClientFeedback>(ClientFeedback =>
        {
            ClientFeedback.ConfigureByConvention();
        });
        builder.Entity<Document>(Document =>
        {
            Document.ConfigureByConvention();
        });
        builder.Entity<ApplicationUser>(ApplicationUser =>
        {
            ApplicationUser.ConfigureByConvention();
        });

        builder.Entity<ApprovedTeam>(ApprovedTeam => {
          ApprovedTeam.ConfigureByConvention();
        });

        builder.Entity<AuditHistory>(AuditHistory => {
          AuditHistory.ConfigureByConvention();
        });

        builder.Entity<ProjectOverview>(b =>
         {
            b.ConfigureByConvention();
        });

        builder.Entity<StakeAndScope>(b =>
        {
             b.ConfigureByConvention();
        });

        builder.Entity<Stakeholder>(Phase =>
        {
          Phase.ConfigureByConvention();
        });

        builder.Entity<RemediationStep>(Phase =>
        {
          Phase.ConfigureByConvention();
        });


  }
}
