using Microsoft.EntityFrameworkCore;
using SimpleCV.Data.Entities;

namespace SimpleCV.Data.DataContext.Conf
{
    public class SkillConf : IEntityTypeConfiguration<Skill>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Skill> builder)
        {
            builder.ToTable("skill");
            builder.HasKey(x => x.SkillId);
            builder.Property(x => x.SkillId).HasColumnName("skill_id");
            builder.Property(x => x.SkillName).HasColumnName("skill_name");
            builder.Property(x => x.Level).HasColumnName("level").IsRequired(false);
            builder.Property(x => x.SkillType).HasColumnName("skill_type");
            builder.Property(x => x.SkillTitle).HasColumnName("skill_title");
        }
    }
}