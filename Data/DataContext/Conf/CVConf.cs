using Microsoft.EntityFrameworkCore;
using SimpleCV.Data.Entities;

namespace SimpleCV.Data.DataContext.Conf
{
    public class CVConf : IEntityTypeConfiguration<CV>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CV> builder)
        {
            builder.ToTable("cv");
            builder.HasKey(x => x.CVId);
            builder.Property(x => x.CVId).HasColumnName("cv_id");
            builder.Property(x => x.CreateDate).HasColumnName("create_date");
            builder.Property(x => x.CVUrl).HasColumnName("cv_url").IsRequired(false);
        }
    }
}