using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using IoT.Dashboard.Entities;

namespace IoT.Dashboard.Data
{
    public class IoTDbContext : DbContext
    {
        public DbSet<UserProfile> UserProfiles { get; set; } 
        public DbSet<Device> Devices { get; set; }
        public DbSet<Signal> Signals { get; set; }
        public DbSet<Entities.Dashboard> Dashboards { get; set; }
        public DbSet<DashboardDevice> DashboardDevices { get; set; }

        /// <summary>
        /// IoTDbContext will be created with option AutoDetectChangesEnabled = false by default
        /// </summary>
        public IoTDbContext()
        {
            Configuration.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}
