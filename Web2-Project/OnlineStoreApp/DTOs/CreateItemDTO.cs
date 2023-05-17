using System.ComponentModel.DataAnnotations;

namespace OnlineStoreApp.DTOs
{
    public class CreateItemDTO
    {
        [Required]
        public int Amount { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}
