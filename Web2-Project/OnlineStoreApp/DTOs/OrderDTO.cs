using System.ComponentModel.DataAnnotations;

namespace OnlineStoreApp.DTOs
{
    public class OrderDTO : CreateOrderDTO
    {
        [Required]
        public int Id { get; set; }
    }
}
