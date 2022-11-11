using Microsoft.EntityFrameworkCore;
using SimpleCV.Data.Entities;

namespace SimpleCV.Data.DataContext.Conf
{
    public class CVSkillConf : IEntityTypeConfiguration<CVSkill>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CVSkill> builder)
        {
            builder.ToTable("cv_skill");
            builder.HasKey(x => new { x.CVId, x.SkillId });
            builder.Property(x => x.CVId).HasColumnName("cv_id");
            builder.Property(x => x.SkillId).HasColumnName("skill_id");
        }
    }
}