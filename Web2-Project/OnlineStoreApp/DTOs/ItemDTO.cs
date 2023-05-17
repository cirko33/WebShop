using OnlineStoreApp.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineStoreApp.DTOs
{
    public class ItemDTO : CreateItemDTO
    {
        public CreateProductDTO? Product { get; set; }
    }
}
