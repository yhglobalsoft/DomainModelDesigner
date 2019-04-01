using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DomainModelDesigner.Designer.Host
{
    public class DemoAppDbContextFactory : IDesignTimeDbContextFactory<DemoAppDbContext>
    {
        //private readonlovider)y IServiceProvider _serviceProvider;
        //public DemoAppDbContextFactory(IServiceProvider servicePr
        //{
        //    _serviceProvider = serviceProvider;
        //}

        public DemoAppDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<DemoAppDbContext>()
                .UseMySql(configuration.GetConnectionString("Default"));

            return new DemoAppDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
