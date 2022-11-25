using Microsoft.EntityFrameworkCore;
using SimpleCV.Data.DataContext.Conf;
using SimpleCV.Data.Entities;

namespace SimpleCV.Data.DataContext.EF
{
    public class PgDbContext : DbContext
    {
        public PgDbContext(DbContextOptions<PgDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConf());
            modelBuilder.ApplyConfiguration(new CVConf());
            modelBuilder.ApplyConfiguration(new ActivityConf());
            modelBuilder.ApplyConfiguration(new SkillConf());
            modelBuilder.ApplyConfiguration(new InfoConf());
            modelBuilder.ApplyConfiguration(new DescriptionConf());
            modelBuilder.ApplyConfiguration(new CVSkillConf());

            /*
            * Config FLUENT API
            */

            /// 1:1 - Activity:Description
            modelBuilder.Entity<Activity>()
                .HasOne(act => act.RefDescription)
                .WithOne(des => des.RefActivity)
                .HasForeignKey<Description>(nav => nav.ActivityId);

            /// 1:1 - CV : Info
            modelBuilder.Entity<CV>()
                .HasOne(cv => cv.RefInfo)
                .WithOne(info => info.RefCV)
                .HasForeignKey<Info>(nav => nav.CVId);

            /// n:1 - CV : Activity
            modelBuilder.Entity<Activity>()
                .HasOne(act => act.RefCV)
                .WithMany(cv => cv.Activities)
                .HasForeignKey(act => act.CVId);

            /// n:1 - CV : CVSkill
            modelBuilder.Entity<CVSkill>()
                .HasOne(cvSkill => cvSkill.RefCV)
                .WithMany(cv => cv.CVSkills);

            /// 1:n - CVSkill : Skill
            modelBuilder.Entity<CVSkill>()
                .HasOne(cvSkill => cvSkill.RefSkill)
                .WithMany(skill => skill.CVSkills);

            /// 1:n - Account : CV
            modelBuilder.Entity<CV>()
                .HasOne(cv => cv.RefAccount)
                .WithMany(acc => acc.CVs)
                .HasForeignKey(cv => cv.AccountId);
        }

        public DbSet<CV> CVs { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Info> Info { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<CVSkill> CVSkills { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}