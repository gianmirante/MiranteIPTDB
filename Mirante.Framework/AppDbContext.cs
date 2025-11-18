using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mirante.Domain.Models;

namespace Mirante.Framework
{
    namespace MiranteCFramework.DbContext
    {
        public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            public DbSet<DoctorAppointment> DoctorAppointments { get; set; } = null!;
        }
    }
}

