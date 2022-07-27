using ECommerce.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.Configurations
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ProjectDbContext>
    {
        public ProjectDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ProjectDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(ConnectionString.Get());
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
