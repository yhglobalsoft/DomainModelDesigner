using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.AspNetCore;
using Microsoft.Extensions.Configuration;

namespace DomainModelDesigner.Designer.EntityFrameworkCore
{
    [DependsOn(
        typeof(DesignerTestBaseModule),
        typeof(DesignerEntityFrameworkCoreModule)
        )]
    public class DesignerEntityFrameworkCoreTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<DbConnectionOptions>(options =>
            {
                var sqlConn = "server=localhost;database=DMD_Designer;uid=root;pwd=123456.com;";
                options.ConnectionStrings.Default = sqlConn;
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
        }
        //public override void ConfigureServices(ServiceConfigurationContext context)
        //{
        //    var sqliteConnection = CreateDatabaseAndGetConnection();

        //    Configure<AbpDbContextOptions>(options =>
        //    {
        //        options.Configure(abpDbContextConfigurationContext =>
        //        {
        //            abpDbContextConfigurationContext.DbContextOptions.UseSqlite(sqliteConnection);
        //        });
        //    });
        //}

        //private static SqliteConnection CreateDatabaseAndGetConnection()
        //{
        //    var connection = new SqliteConnection("Data Source=:memory:");
        //    connection.Open();

        //    new DesignerDbContext(
        //        new DbContextOptionsBuilder<DesignerDbContext>().UseSqlite(connection).Options
        //    ).GetService<IRelationalDatabaseCreator>().CreateTables();

        //    return connection;
        //}
    }
}
