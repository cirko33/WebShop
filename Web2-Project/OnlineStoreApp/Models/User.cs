using System.ComponentModel.DataAnnotations;

namespace OnlineStoreApp.Models
{
    public enum UserType { Administrator, Seller, Buyer }
    public class User : BaseClass
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Firstname { get; set; }
        [Required]
        public string? Lastname { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public UserType Type { get; set; }
        public byte[]? Image { get; set; }
    }
}
