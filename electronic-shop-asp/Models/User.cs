using System.ComponentModel.DataAnnotations;

namespace electronic_shop_asp.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string Role { get; set; } = "User";

        public Cart? Cart { get; set; }
    }
}