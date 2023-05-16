using System.ComponentModel.DataAnnotations;

namespace OnlineStoreApp.Models
{
    public enum OrderStatus { InDelivery = 0, Delivered = 1, Cancelled = 2 }
    public class Order : BaseClass
    {
        public List<Item>? Items { get; set; }
        [Required, MaxLength(100)]
        public string? DeliveryAddress { get; set; }
        [Required]
        public DateTime DeliveryTime { get; set; }
        public string? Comment { get; set; }
        [Required]
        public OrderStatus OrderStatus { get; set; }
    }
}
