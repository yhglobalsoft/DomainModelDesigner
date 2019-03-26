using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DomainModelDesigner.Designer.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using Volo.Abp;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.Security.Claims;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.VirtualFileSystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.AspNetCore;
using FluentValidation.Attributes;

namespace DomainModelDesigner.Designer.Host
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(DesignerApplicationModule),
        typeof(DesignerEntityFrameworkCoreModule),
        typeof(DesignerHttpApiModule),
        typeof(AbpPermissionManagementEntityFrameworkCoreModule),
        typeof(AbpSettingManagementEntityFrameworkCoreModule),
        typeof(AbpAuditLoggingEntityFrameworkCoreModule)
        )]
    public class DemoAppModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.BuildConfiguration();

            Configure<DbConnectionOptions>(options =>
            {
                options.ConnectionStrings.Default = configuration.GetConnectionString("Default");
            });

            Configure<AbpDbContextOptions>(options =>
            {
                options.Configure(cxt =>
                {
                    if (cxt.ExistingConnection != null)
                    {
                        cxt.DbContextOptions.UseMySql(cxt.ExistingConnection);
                    }
                    else
                    {
                        cxt.DbContextOptions.UseMySql(cxt.ConnectionString);
                    }
                });
            });


            if (hostingEnvironment.IsDevelopment())
            {
                Configure<VirtualFileSystemOptions>(options =>
                {
                    options.FileSets.ReplaceEmbeddedByPhysical<DesignerDomainModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}DomainModelDesigner.Designer.Domain", Path.DirectorySeparatorChar)));
                    options.FileSets.ReplaceEmbeddedByPhysical<DesignerApplicationModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}DomainModelDesigner.Designer.Application", Path.DirectorySeparatorChar)));
                    options.FileSets.ReplaceEmbeddedByPhysical<DesignerApplicationContractsModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}DomainModelDesigner.Designer.Application.Contracts", Path.DirectorySeparatorChar)));
                });
            }

            context.Services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new Info { Title = "Designer API", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                    options.CustomSchemaIds(type => type.FullName);
                });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Languages.Add(new LanguageInfo("en", "en", "English"));
                //...add other languages
            });

            //context.Services.AddDistributedSqlServerCache(options =>
            //{
            //    options.ConnectionString = configuration.GetConnectionString("SqlServerCache");
            //    options.SchemaName = "dbo";
            //    options.TableName = "TestCache";
            //});

            context.Services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "http://localhost:61517";
                    options.RequireHttpsMetadata = false;

                    options.ApiName = "api1";

                    //TODO: Can we make this by default?
                    options.InboundJwtClaimTypeMap["sub"] = AbpClaimTypes.UserId;
                    options.InboundJwtClaimTypeMap["role"] = AbpClaimTypes.Role;
                    options.InboundJwtClaimTypeMap["email"] = AbpClaimTypes.Email;
                });

            //context.Services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            //    .AddFluentValidation(cfg =>
            //    {
            //        cfg.ValidatorFactoryType = typeof(AttributedValidatorFactory);
            //        cfg.ImplicitlyValidateChildProperties = false;
            //    }); 
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            //app.ApplicationServices.GetService<>();

            app.UseVirtualFiles();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Support APP API");
            });

            app.UseAuthentication();
            app.UseAbpRequestLocalization();
            app.UseAuditing();

            app.UseMvcWithDefaultRoute();
        }
    }
}
