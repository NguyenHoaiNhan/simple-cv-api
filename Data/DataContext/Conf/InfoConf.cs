using Microsoft.EntityFrameworkCore;
using SimpleCV.Data.Entities;

namespace SimpleCV.Data.DataContext.Conf
{
    public class InfoConf : IEntityTypeConfiguration<Info>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Info> builder)
        {
            builder.ToTable("info");
            builder.HasKey(x => x.CVId);
            builder.Property(x => x.CVId).HasColumnName("cv_id");
            builder.Property(x => x.GivenName).HasColumnName("given_name").IsRequired(false);
            builder.Property(x => x.FamilyName).HasColumnName("family_name").IsRequired(false);
            builder.Property(x => x.Email).HasColumnName("email").IsRequired(false);
            builder.Property(x => x.HeadLine).HasColumnName("headline").IsRequired(false);
            builder.Property(x => x.PhoneNum).HasColumnName("phone_num").IsRequired(false);
            builder.Property(x => x.Address).HasColumnName("address").IsRequired(false);
            builder.Property(x => x.PostCode).HasColumnName("post_code").IsRequired(false);
            builder.Property(x => x.City).HasColumnName("city").IsRequired(false);
            builder.Property(x => x.DateOfBirth).HasColumnName("date_of_birth").IsRequired(false);
            builder.Property(x => x.PlaceOfBirth).HasColumnName("place_of_birth").IsRequired(false);
            builder.Property(x => x.DriverLicense).HasColumnName("driver_license").IsRequired(false);
            builder.Property(x => x.Gender).HasColumnName("gender").IsRequired(false);
            builder.Property(x => x.CountryId).HasColumnName("country_id").IsRequired(false);
            builder.Property(x => x.CivilStatusId).HasColumnName("civil_status_id").IsRequired(false);
            builder.Property(x => x.GithubLink).HasColumnName("github_link").IsRequired(false);
            builder.Property(x => x.LinkedinLink).HasColumnName("linkedin_link").IsRequired(false);
            builder.Property(x => x.Avatar).HasColumnName("avatar").IsRequired(false);
            builder.Property(x => x.CivilStatus).HasColumnName("civil_status").IsRequired(false);
            builder.Property(x => x.Country).HasColumnName("country").IsRequired(false);
            builder.Property(x => x.InfoTitle).HasColumnName("info_title");
        }
    }
}