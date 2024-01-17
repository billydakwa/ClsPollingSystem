using Billy.CLC.PollingSystem.Angular.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Billy.CLC.PollingSystem.Angular.Server.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Poll>().ToTable("polls");
            modelBuilder.Entity<Vote>().ToTable("votes");

        }
    }
}
