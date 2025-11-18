using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Mirante.Framework
{

    namespace MiranteCFramework.DbContext
    {
        public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
        {
            public AppDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                optionsBuilder.UseSqlServer("ConnectionStringHere"); // Replace with appsettings.json later
                return new AppDbContext(optionsBuilder.Options);
            }
        }
    }
}
