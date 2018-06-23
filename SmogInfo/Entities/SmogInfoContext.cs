using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmogInfo.Entities
{
    public class SmogInfoContext : DbContext
    {
        public SmogInfoContext(DbContextOptions<SmogInfoContext> options)
            :base(options)
        {
            Database.Migrate();
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<StationPoint> StationPoints { get; set; }
        public DbSet<SmogLevel> SmogLevels { get; set; }
    }
}
