using OnlineStoreApp.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineStoreApp.DTOs
{
    public class OrderItemDTO
    {
        [Required]
        public int ProductId { get; set; }
        public CreateProductDTO? Product { get; set; }
        [Required]
        public int Amount { get; set; }

    }
}
