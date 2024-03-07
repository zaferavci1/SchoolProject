using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SchoolProject.Persistence.Configurations;
namespace SchoolProject.Persistence.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SchoolProjectDbContext>
    {
        public DesignTimeDbContextFactory()
        {
        }
        public SchoolProjectDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<SchoolProjectDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
            return new SchoolProjectDbContext(dbContextOptionsBuilder.Options);
        }

    }
}

