using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleCV.Data.Entities;

namespace SimpleCV.Data.DataContext.Conf
{
    public class UserConf : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.FirstName).HasColumnName("first_name");
            builder.Property(x => x.FamilyName).HasColumnName("family_name");
            builder.Property(x => x.MidName).HasColumnName("mid_name");
            builder.Property(x => x.Phone).HasColumnName("phone");
            builder.Property(x => x.Address).HasColumnName("address");
        }
    }
}