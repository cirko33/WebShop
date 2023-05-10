using System.ComponentModel.DataAnnotations;

namespace OnlineStoreApp.Models
{
    public class Product : BaseClass
    {
        [Required, MaxLength(50)]
        public string? Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required, MaxLength(200)]
        public string? Description { get; set; }
        [Required]
        public byte[]? Image { get; set; }
    }
}
