using URLShortener.Enums;

namespace URLShortener.Models
{
    public class User
    {
        public int? UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserRoleEnum Role { get; set; } = UserRoleEnum.User;

        public ICollection<UrlShortener> Urls { get; set; }
    }
}
