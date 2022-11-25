using Microsoft.EntityFrameworkCore;
using SimpleCV.Data.Entities;

namespace SimpleCV.Data.DataContext.Conf
{
    public class DescriptionConf : IEntityTypeConfiguration<Description>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Description> builder)
        {
            builder.ToTable("description");
            builder.HasKey(x => x.ActivityId);
            builder.Property(x => x.ActivityId).HasColumnName("act_id");
            builder.Property(x => x.IsBold).HasColumnName("is_bold").IsRequired(false);
            builder.Property(x => x.IsItalic).HasColumnName("is_italic").IsRequired(false);
            builder.Property(x => x.IsUnderline).HasColumnName("is_underline").IsRequired(false);
            builder.Property(x => x.BulletType).HasColumnName("bullet_type").IsRequired(false);
            builder.Property(x => x.Alignment).HasColumnName("alignment");
            builder.Property(x => x.DescriptionPara).HasColumnName("description_paragraph").IsRequired(false);
        }
    }
}