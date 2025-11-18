using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiranteCIPT101Solution.MiranteFramework.DTOs;

namespace MiranteCIPT101Solution.MiranteFramework
{
    public class YouTubeViewersDbContext : DbContext
    {
        public YouTubeViewersDbContext(DbContextOptions options) : base(options) { }

        public DbSet<YouTubeViewerDto> YouTubeViewers { get; set; }
    }
}
