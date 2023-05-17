using System.ComponentModel.DataAnnotations;

namespace OnlineStoreApp.DTOs
{
    public class CreateProductDTO
    {
        [Required, MaxLength(100)]
        public string? Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required, MaxLength(200)]
        public string? Description { get; set; }
        public byte[]? Image { get; set; }
        public string? ImageToImg { get; set; }
    }
}
