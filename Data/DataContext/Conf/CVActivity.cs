using Microsoft.EntityFrameworkCore;
using SimpleCV.Data.Entities;

namespace SimpleCV.Data.DataContext.Conf
{
    public class CVActivityConf : IEntityTypeConfiguration<CVActivity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CVActivity> builder)
        {
            builder.ToTable("cv_activity");
            builder.HasKey(x => new {x.CVId, x.ActivityId});
            builder.Property(x => x.CVId).HasColumnName("cv_id");
            builder.Property(x => x.ActivityId).HasColumnName("act_id");
        }
    }
}