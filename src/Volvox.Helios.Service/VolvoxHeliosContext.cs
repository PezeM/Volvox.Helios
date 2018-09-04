using Microsoft.EntityFrameworkCore;
using Volvox.Helios.Domain.ModuleSettings;
using Volvox.Helios.Service.Extensions;

namespace Volvox.Helios.Service
{
    public class VolvoxHeliosContext : DbContext
    {
        public VolvoxHeliosContext(DbContextOptions options)
            : base(options)
        { }
        
        public DbSet<StreamAnnouncerSettings> StreamAnnouncerSettings { get; set; }

        public DbSet<StreamerRoleSettings> StreamerRoleSettings { get; set; }

        public DbSet<LookingForGroupSettings> LookingForGroupSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.BuildLookingForGroupEntities();

            base.OnModelCreating(modelBuilder);
        }
    }
}