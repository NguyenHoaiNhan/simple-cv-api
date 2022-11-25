using Microsoft.EntityFrameworkCore;
using SimpleCV.Data.Entities;

namespace SimpleCV.Data.DataContext.Conf
{
    public class ActivityConf : IEntityTypeConfiguration<Activity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Activity> builder)
        {
           builder.ToTable("activity");
           builder.HasKey(x => x.ActId);
           builder.Property(x => x.ActId).HasColumnName("act_id");
           builder.Property(x => x.Position).HasColumnName("position").IsRequired(false);
           builder.Property(x => x.Organization).HasColumnName("organization").IsRequired(false);
           builder.Property(x => x.City).HasColumnName("city").IsRequired(false);
           builder.Property(x => x.StartDate).HasColumnName("start_date").IsRequired(false);
           builder.Property(x => x.EndDate).HasColumnName("end_date").IsRequired(false);
           builder.Property(x => x.ActivityType).HasColumnName("activity_type");
           builder.Property(x => x.CVId).HasColumnName("cv_id");
        }
    }
}