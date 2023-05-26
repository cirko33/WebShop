using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStoreApp.Models;
using System.Reflection.Emit;

namespace OnlineStoreApp.Settings
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Order).WithMany(x => x.Items).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Product).WithMany(x => x.Items).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.CurrentPrice).IsRequired();
            builder.Property(x => x.Amount).IsRequired();

            builder.HasData(new Item
            {
                Id = 1,
                ProductId = 1,
                OrderId = 1,
                CurrentPrice = 100,
                Amount = 5
            });
        }
    }
}
