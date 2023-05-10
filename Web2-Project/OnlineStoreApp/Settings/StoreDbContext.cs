using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineStoreApp.Models;

namespace OnlineStoreApp.Settings
{
    public class StoreDbContext : DbContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public StoreDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().Property(x => x.Username).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<User>().HasIndex(x => x.Username).IsUnique();
            modelBuilder.Entity<User>().Property(x => x.Email).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<User>().Property(x => x.Password).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Firstname).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Lastname).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Address).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Birthday).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Type).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Type).HasConversion(new EnumToStringConverter<UserType>());

            modelBuilder.Entity<Product>().HasKey(x => x.Id);
            modelBuilder.Entity<Product>().Property(x => x.Price).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.Amount).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.Description).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.Name).HasMaxLength(50).IsRequired();

            modelBuilder.Entity<Item>().HasKey(x => x.Id);
            modelBuilder.Entity<Item>().Property(x => x.ProductId).IsRequired();
            modelBuilder.Entity<Item>().Property(x => x.Amount).IsRequired();

            modelBuilder.Entity<Order>().HasKey(x => x.Id);
            modelBuilder.Entity<Order>().HasMany(x => x.Items);


            modelBuilder.Entity<Order>().HasData(new Product
            {
                Id = 1,
                Price = 1,
                Amount = 1,
                Description = "sad",
                Name = "sda"
            }); ;
            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = 1,
                DeliveryAddress = "asd",
                DeliveryTime = DateTime.Now,
                Items = new List<Item> { new Item { Id = 1, Amount = 1, OrderId = 1, ProductId = 1 } }
            }); ;
        }
    }
}
