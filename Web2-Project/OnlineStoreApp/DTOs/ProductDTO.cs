using System.ComponentModel.DataAnnotations;

namespace OnlineStoreApp.DTOs
{
    public class ProductDTO : CreateProductDTO
    {
        [Required]
        public int Id { get; set; }
    }
}
