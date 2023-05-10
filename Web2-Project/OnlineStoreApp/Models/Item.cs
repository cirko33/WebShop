using System.ComponentModel.DataAnnotations;

namespace OnlineStoreApp.Models
{
    public class Item : BaseClass
    {
        [Required]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public int OrderId { get; set; }
        public Order? Order { get; set; }
    }
}
