using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;
using OnlineStoreApp.Models;

namespace OnlineStoreApp.Settings
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Username).HasMaxLength(100).IsRequired();
            builder.HasIndex(x => x.Username).IsUnique();
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.FullName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Type).HasConversion(new EnumToStringConverter<UserType>()).IsRequired();
            builder.Property(x => x.Birthday).IsRequired();
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.VerificationStatus).HasConversion(new EnumToStringConverter<VerificationStatus>()).IsRequired();

            builder.HasData(new User
            {
                Id = 1,
                Username = "luka",
                Email = "luka@luka.com",
                FullName = "Luka Ciric",
                Password = BCrypt.Net.BCrypt.HashPassword("123"),
                Address = "Nest 123",
                Type = UserType.Administrator,
                Birthday = new DateTime(1978, 12, 11)
            });
        }
    }
}
