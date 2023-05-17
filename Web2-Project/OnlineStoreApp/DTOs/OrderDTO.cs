using System.ComponentModel.DataAnnotations;

namespace OnlineStoreApp.DTOs
{
    public class OrderDTO
    {
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string? DeliveryAddress { get; set; }
        public string? Comment { get; set; }
        public List<ItemDTO>? Items { get; set; }
    }
}
