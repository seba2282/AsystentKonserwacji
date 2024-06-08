using Microsoft.EntityFrameworkCore;
using AsystentKonserwacji.Models;

namespace AsystentKonserwacji.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Machine> Machines { get; set; }
        public DbSet<LubricationPoint> LubricationPoints { get; set; }
        public DbSet<MaintenanceSchedule> MaintenanceSchedules { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Machine>()
                .HasMany(m => m.LubricationPoints)
                .WithOne(lp => lp.Machine)
                .HasForeignKey(lp => lp.MachineId);

            modelBuilder.Entity<LubricationPoint>()
                .HasMany(lp => lp.MaintenanceSchedules)
                .WithOne(ms => ms.LubricationPoint)
                .HasForeignKey(ms => ms.LubricationPointId);
        }
    }
}