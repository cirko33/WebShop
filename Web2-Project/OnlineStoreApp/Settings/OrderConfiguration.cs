using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OnlineStoreApp.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace OnlineStoreApp.Settings
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DeliveryAddress).HasMaxLength(200).IsRequired();
            builder.Property(x => x.DeliveryTime).IsRequired();
            builder.Property(x => x.Comment).HasMaxLength(200);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.OrderStatus).HasConversion(new EnumToStringConverter<OrderStatus>()).IsRequired();
        }
    }
}
