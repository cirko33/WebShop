using System.ComponentModel.DataAnnotations;

namespace OnlineStoreApp.Models
{
    public enum UserType { Administrator = 0, Seller = 1, Buyer = 2}
    public enum VerificationStatus { Waiting = 0, Accepted = 1, Declined = 2}
    public class User : BaseClass
    {
        [Required, MaxLength(100)]
        public string? Username { get; set; }
        [Required, MaxLength(300)]
        public string? Password { get; set; }
        [Required, MaxLength(100)]
        public string? Email { get; set; }
        [Required, MaxLength(100)]
        public string? FullName { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required, MaxLength(200)]
        public string? Address { get; set; }
        [Required]
        public UserType Type { get; set; }
        [Required]
        public VerificationStatus VerificationStatus { get; set; }
        public byte[]? Image { get; set; }
    }
}
