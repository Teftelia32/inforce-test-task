using System.ComponentModel.DataAnnotations;

namespace URLShortener.DTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Username is required.")]
        public string Password { get; set; }
    }
}
