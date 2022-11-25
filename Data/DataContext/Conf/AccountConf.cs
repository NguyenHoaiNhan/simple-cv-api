using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleCV.Data.Entities;

namespace SimpleCV.Data.DataContext.Conf
{
    public class AccountConf : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("account");
            builder.HasKey(x => x.AccountId);
            builder.Property(x => x.AccountId).HasColumnName("account_id");
            builder.Property(x => x.AccountPwd).HasColumnName("account_pwd");
            builder.Property(x => x.AccountName).HasColumnName("account_name").IsRequired(false);
            builder.Property(x => x.PhoneNumber).HasColumnName("phone_number").IsRequired(false);
            builder.Property(x => x.Email).HasColumnName("email").IsRequired(false);
        }
    }
}