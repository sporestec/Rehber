using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Rehber.Database.Models
{
    public class RehberContext : DbContext
    {

        public RehberContext()
        {
        }

        public RehberContext(DbContextOptions<RehberContext> options)
               : base(options)
        { }


        public class CatalogContextDesignFactory : IDesignTimeDbContextFactory<RehberContext>
        {
            public RehberContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

                var optionsBuilder = new DbContextOptionsBuilder<RehberContext>()
                    .UseSqlServer(configuration["ConnectionString"]);

                return new RehberContext(optionsBuilder.Options);
            }
        }
    }
}
