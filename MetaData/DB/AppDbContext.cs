using MetaData.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MetaData.DB
{
    public class AppDbContext: IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // props // add classes as tables in db 

        public DbSet<MainInfo> MainInfos { get; set; }
        public DbSet<UserD> UserDs { get; set; }
        public DbSet<VectorData> VectorsData { get; set; }
        public DbSet<RasterData> RastersData { get; set; }
        public DbSet<SatelliteData> SatelltiesData { get; set; }
    }
}
