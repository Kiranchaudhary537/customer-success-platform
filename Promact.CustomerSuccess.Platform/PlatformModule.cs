using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using Promact.CustomerSuccess.Platform.Data;
using Promact.CustomerSuccess.Platform.Localization;
using OpenIddict.Validation.AspNetCore;
using Volo.Abp;
using Volo.Abp.Uow;
using Volo.Abp.Account;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.LeptonXLite;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.LeptonXLite.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.Emailing;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.PostgreSql;
using Volo.Abp.FeatureManagement;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.PermissionManagement.OpenIddict;
using Volo.Abp.SettingManagement;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.Swashbuckle;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Abp.OpenIddict;
using Volo.Abp.Security.Claims;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Test.Authorization;
using Test.Requirement;
using Volo.Abp.Authorization;

namespace Promact.CustomerSuccess.Platform;

[DependsOn(
    // ABP Framework packages
    typeof(AbpAspNetCoreMvcModule),
    typeof(AbpAspNetCoreMultiTenancyModule),
    typeof(AbpAutofacModule),
    typeof(AbpAutoMapperModule),
    typeof(AbpEntityFrameworkCorePostgreSqlModule),
    typeof(AbpAspNetCoreMvcUiLeptonXLiteThemeModule),
    typeof(AbpSwashbuckleModule),
    typeof(AbpAspNetCoreSerilogModule),

    // Account module packages
    typeof(AbpAccountApplicationModule),
    typeof(AbpAccountHttpApiModule),
    typeof(AbpAccountWebOpenIddictModule),

    // Identity module packages
    typeof(AbpPermissionManagementDomainIdentityModule),
    typeof(AbpPermissionManagementDomainOpenIddictModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpIdentityHttpApiModule),
    typeof(AbpIdentityEntityFrameworkCoreModule),
    typeof(AbpOpenIddictEntityFrameworkCoreModule),

    // Audit logging module packages
    typeof(AbpAuditLoggingEntityFrameworkCoreModule),

    // Permission Management module packages
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpPermissionManagementHttpApiModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),

    // Tenant Management module packages
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpTenantManagementHttpApiModule),
    typeof(AbpTenantManagementEntityFrameworkCoreModule),

    // Feature Management module packages
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpFeatureManagementEntityFrameworkCoreModule),
    typeof(AbpFeatureManagementHttpApiModule),

    // Setting Management module packages
    typeof(AbpSettingManagementApplicationModule),
    typeof(AbpSettingManagementEntityFrameworkCoreModule),
    typeof(AbpSettingManagementHttpApiModule)
)]
public class PlatformModule : AbpModule
{
    /* Single point to enable/disable multi-tenancy */
    private const bool IsMultiTenant = true;
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        var configuration = context.Services.GetConfiguration();

        context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
        {
            options.AddAssemblyResource(
                typeof(PlatformResource)
            );
        });

        PreConfigure<OpenIddictBuilder>(builder =>
        {
            builder.AddValidation(options =>
            {
                options.AddAudiences("Platform");
                options.UseLocalServer();
                options.UseAspNetCore();
            });
        });

        if (!hostingEnvironment.IsDevelopment())
        {
            PreConfigure<AbpOpenIddictAspNetCoreOptions>(options =>
            {
                options.AddDevelopmentEncryptionAndSigningCertificate = false;
            });

            PreConfigure<OpenIddictServerBuilder>(serverBuilder =>
            {
                serverBuilder.AddProductionEncryptionAndSigningCertificate("openiddict.pfx", "a2a5a8af-14c6-4374-a8f3-908165814c47");
            });
        }
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        var configuration = context.Services.GetConfiguration();

        if (hostingEnvironment.IsDevelopment())
        {
            context.Services.Replace(ServiceDescriptor.Singleton<IEmailSender, NullEmailSender>());
        }

        ConfigureAuthentication(context,configuration);
        ConfigureBundles();
        ConfigureMultiTenancy();
        ConfigureUrls(configuration);
        ConfigureAutoMapper(context);
        ConfigureSwagger(context.Services, configuration);
        ConfigureAutoApiControllers();
        ConfigureVirtualFiles(hostingEnvironment);
        ConfigureLocalization();
        ConfigureCors(context, configuration);
        ConfigureDataProtection(context);
        ConfigureEfCore(context);
  
    }

    private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
    {

        // Forward authentication for bearer token
        context.Services.ForwardIdentityAuthenticationForBearer(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
        
        // Configure ABP claims principal factory options
        context.Services.Configure<AbpClaimsPrincipalFactoryOptions>(options =>
        {
            options.IsDynamicClaimsEnabled = true;
        });

        // Add JWT authentication
        context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                        .AddJwtBearer(options =>
                        {
                            var audience = configuration["Auth0:Audience"];
                            var authority = configuration["Auth0:Authority"];
                            options.Authority = authority;
                            options.Audience = audience;
                            options.RequireHttpsMetadata = false;
                            options.MetadataAddress = $"{authority}/.well-known/openid-configuration";
                            options.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateAudience = true,
                                ValidateIssuerSigningKey = true,
                                IssuerSigningKeyResolver = (token, securityToken, kid, validationParameters) =>
                                {
                                    var resolver = new DynamicOpenIdConnectSigningKeyResolver();
                                    return resolver.GetSigningKeysAsync().Result; // Await the asynchronous task
                                },
                            };
                        });

        // Add authorization policies
        context.Services.AddAuthorization(options =>
        {
            // Project policies
            options.AddPolicy("read:project", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("read:project"));
            });
            options.AddPolicy("create:project", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("create:project"));
            });
            options.AddPolicy("update:project", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("update:project"));
            });
            options.AddPolicy("delete:project", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("delete:project"));
            });

            // Approved team policies
            options.AddPolicy("read:approved-team", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("read:approved-team"));
            });
            options.AddPolicy("create:approved-team", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("create:approved-team"));
            });
            options.AddPolicy("update:approved-team", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("update:approved-team"));
            });
            options.AddPolicy("delete:approved-team", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("delete:approved-team"));
            });


            // audit history policies
            options.AddPolicy("read:audit-history", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("read:audit-history"));
            });
            options.AddPolicy("create:audit-history", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("create:audit-history"));
            });
            options.AddPolicy("update:audit-history", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("update:audit-history"));
            });
            options.AddPolicy("delete:audit-history", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("delete:audit-history"));
            });

            // client feedback policies
            options.AddPolicy("read:client-feedback", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("read:client-feedback"));
            });
            options.AddPolicy("create:client-feedback", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("create:client-feedback"));
            });
            options.AddPolicy("update:client-feedback", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("update:client-feedback"));
            });
            options.AddPolicy("delete:client-feedback", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("delete:client-feedback"));
            });

            // risk profile policies
            options.AddPolicy("read:risk-profile", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("read:risk-profile"));
            });
            options.AddPolicy("create:risk-profile", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("create:risk-profile"));
            });
            options.AddPolicy("update:risk-profile", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("update:risk-profile"));
            });
            options.AddPolicy("delete:risk-profile", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("delete:risk-profile"));
            });

            // escalation matrix policies
            options.AddPolicy("read:escalation-matrix", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("read:escalation-matrix"));
            });
            options.AddPolicy("create:escalation-matrix", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("create:escalation-matrix"));
            });
            options.AddPolicy("update:escalation-matrix", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("update:escalation-matrix"));
            });
            options.AddPolicy("delete:escalation-matrix", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("delete:escalation-matrix"));
            });

            // meeting minute policies
            options.AddPolicy("read:meeting-minute", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("read:meeting-minute"));
            });
            options.AddPolicy("create:meeting-minute", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("create:meeting-minute"));
            });
            options.AddPolicy("update:meeting-minute", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("update:meeting-minute"));
            });
            options.AddPolicy("delete:meeting-minute", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("delete:meeting-minute"));
            });

            // phase policies
            options.AddPolicy("read:phase", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("read:phase"));
            });
            options.AddPolicy("create:phase", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("create:phase"));
            });
            options.AddPolicy("update:phase", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("update:phase"));
            });
            options.AddPolicy("delete:phase", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("delete:phase"));
            });

            // version history policies
            options.AddPolicy("read:version-history", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("read:version-history"));
            });
            options.AddPolicy("create:version-history", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("create:version-history"));
            });
            options.AddPolicy("update:version-history", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("update:version-history"));
            });
            options.AddPolicy("delete:version-history", policy =>
            {
                policy.Requirements.Add(new RbacRequirement("delete:version-history"));
            });
        });

        // Add RBAC handler
        context.Services.AddSingleton<IAuthorizationHandler, RbacHandler>();

    }

    private void ConfigureBundles()
    {
        Configure<AbpBundlingOptions>(options =>
        {
            options.StyleBundles.Configure(
                LeptonXLiteThemeBundles.Styles.Global,
                bundle => { bundle.AddFiles("/global-styles.css"); }
            );
        });
    }

    private void ConfigureMultiTenancy()
    {
        Configure<AbpMultiTenancyOptions>(options =>
        {
            options.IsEnabled = IsMultiTenant;
        });
    }

    private void ConfigureUrls(IConfiguration configuration)
    {
        Configure<AppUrlOptions>(options =>
        {
            options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"];
            options.RedirectAllowedUrls.AddRange(configuration["App:RedirectAllowedUrls"]?.Split(',') ?? Array.Empty<string>());

            options.Applications["Angular"].RootUrl = configuration["App:ClientUrl"];
            options.Applications["Angular"].Urls[AccountUrlNames.PasswordReset] = "account/reset-password";
        });
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<PlatformResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/Platform");

            options.DefaultResourceType = typeof(PlatformResource);

            options.Languages.Add(new LanguageInfo("en", "en", "English"));
            options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe"));
            options.Languages.Add(new LanguageInfo("ar", "ar", "العربية"));
            options.Languages.Add(new LanguageInfo("cs", "cs", "Čeština"));
            options.Languages.Add(new LanguageInfo("en-GB", "en-GB", "English (UK)"));
            options.Languages.Add(new LanguageInfo("hu", "hu", "Magyar"));
            options.Languages.Add(new LanguageInfo("fi", "fi", "Finnish"));
            options.Languages.Add(new LanguageInfo("fr", "fr", "Français"));
            options.Languages.Add(new LanguageInfo("hi", "hi", "Hindi", "in"));
            options.Languages.Add(new LanguageInfo("is", "is", "Icelandic", "is"));
            options.Languages.Add(new LanguageInfo("it", "it", "Italiano", "it"));
            options.Languages.Add(new LanguageInfo("pt-BR", "pt-BR", "Português"));
            options.Languages.Add(new LanguageInfo("ro-RO", "ro-RO", "Română"));
            options.Languages.Add(new LanguageInfo("ru", "ru", "Русский"));
            options.Languages.Add(new LanguageInfo("sk", "sk", "Slovak"));
            options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
            options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文"));
            options.Languages.Add(new LanguageInfo("de-DE", "de-DE", "Deutsch", "de"));
            options.Languages.Add(new LanguageInfo("es", "es", "Español"));
            options.Languages.Add(new LanguageInfo("el", "el", "Ελληνικά"));
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("Platform", typeof(PlatformResource));
        });
    }

    private void ConfigureVirtualFiles(IWebHostEnvironment hostingEnvironment)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<PlatformModule>();
            if (hostingEnvironment.IsDevelopment())
            {
                /* Using physical files in development, so we don't need to recompile on changes */
                options.FileSets.ReplaceEmbeddedByPhysical<PlatformModule>(hostingEnvironment.ContentRootPath);
            }
        });
    }

    private void ConfigureAutoApiControllers()
    {
        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ConventionalControllers.Create(typeof(PlatformModule).Assembly);
        });
    }

    private void ConfigureSwagger(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAbpSwaggerGenWithOAuth(
            configuration["AuthServer:Authority"]!,
            new Dictionary<string, string>
            {
                    {"Platform", "Platform API"}
            },
            options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Platform API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
            });
    }

    private void ConfigureAutoMapper(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<PlatformModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            /* Uncomment `validate: true` if you want to enable the Configuration Validation feature.
             * See AutoMapper's documentation to learn what it is:
             * https://docs.automapper.org/en/stable/Configuration-validation.html
             */
            options.AddMaps<PlatformModule>(/* validate: true */);
        });
    }

    private void ConfigureCors(ServiceConfigurationContext context, IConfiguration configuration)
    {
        context.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder
                    .WithOrigins(
                        configuration["App:CorsOrigins"]?
                            .Split(",", StringSplitOptions.RemoveEmptyEntries)
                            .Select(o => o.RemovePostFix("/"))
                            .ToArray() ?? Array.Empty<string>()
                    )
                    .WithAbpExposedHeaders()
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });
    }

    private void ConfigureDataProtection(ServiceConfigurationContext context)
    {
        context.Services.AddDataProtection().SetApplicationName("Platform");
    }

    private void ConfigureEfCore(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<PlatformDbContext>(options =>
        {
            /* You can remove "includeAllEntities: true" to create
             * default repositories only for aggregate roots
             * Documentation: https://docs.abp.io/en/abp/latest/Entity-Framework-Core#add-default-repositories
             */
            options.AddDefaultRepositories(includeAllEntities: true);
        });

        Configure<AbpDbContextOptions>(options =>
        {
            options.Configure(configurationContext =>
            {
                configurationContext.UseNpgsql();
            });
        });

    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseAbpRequestLocalization();

        if (!env.IsDevelopment())
        {
            app.UseErrorPage();
        }

        app.UseCorrelationId();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors();
        app.UseAuthentication();
        app.UseAbpOpenIddictValidation();

        if (IsMultiTenant)
        {
            app.UseMultiTenancy();
        }

        app.UseUnitOfWork();
        app.UseDynamicClaims();
        app.UseAuthorization();

        app.UseSwagger();
        app.UseAbpSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Platform API");

            var configuration = context.GetConfiguration();
            options.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
            options.OAuthScopes("Platform");
        });

        app.UseAuditing();
        app.UseAbpSerilogEnrichers();
        app.UseConfiguredEndpoints();
    }
}
