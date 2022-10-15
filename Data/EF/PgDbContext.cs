using Microsoft.EntityFrameworkCore;
using SimpleCV.Data.Conf;
using SimpleCV.Data.Entities;

namespace SimpleCV.Data.EF
{
    public class PgDbContext : DbContext
    {
        public PgDbContext(DbContextOptions<PgDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConf());
        }

        public DbSet<User> Users { get; set; }
    }
}