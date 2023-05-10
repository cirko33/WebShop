using System.ComponentModel.DataAnnotations;

namespace OnlineStoreApp.Models
{
    public class Order : BaseClass
    {
        public List<Item>? Items { get; set; }
        [Required]
        public string? DeliveryAddress { get; set; }
        [Required]
        public DateTime DeliveryTime { get; set; }
        public string? Comment { get; set; }
    }
}
