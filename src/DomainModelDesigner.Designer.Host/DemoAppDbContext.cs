using Microsoft.EntityFrameworkCore;
using DomainModelDesigner.Designer.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using System;

namespace DomainModelDesigner.Designer.Host
{
    public class DemoAppDbContext : AbpDbContext<DemoAppDbContext>
    {
        public DemoAppDbContext(DbContextOptions<DemoAppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigurePermissionManagement();
            modelBuilder.ConfigureSettingManagement();
            modelBuilder.ConfigureDesigner();
            modelBuilder.ConfigureAuditLogging();
        }
    }
}
