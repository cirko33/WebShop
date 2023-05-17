using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OnlineStoreApp.Models;
using System.Text;

namespace OnlineStoreApp.Settings
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(200);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

            builder.HasData(new Product
            {
                Id = 1,
                Name = "Test",
                Price = 100,
                Amount = 10,
                Description = "123",
                SellerId = 2,
                Image = Encoding.UTF8.GetBytes("Test")
            });
        }
    }
}
