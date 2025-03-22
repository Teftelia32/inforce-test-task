using URLShortener.DTOs;
using URLShortener.Models;

namespace URLShortener.Managers.Interfaces
{
    public interface IUserManager
    {
        Task<List<UserDto>> GetAllUsersAsync();
        Task<User> RegisterUserAsync(string username, string email, string password);
        Task<User> AuthenticateUserAsync(string username, string password);
    }
}
