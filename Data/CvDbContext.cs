using Microsoft.EntityFrameworkCore;
using SimpleCV.Models;

namespace SimpleCV.Data
{
    public class CvDbContext : DbContext
    {
        public CvDbContext(DbContextOptions<CvDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }

        public DbSet<Users> Users { get; set; }
    }
}