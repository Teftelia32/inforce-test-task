using URLShortener.Models;

namespace URLShortener.Accessors.Interfaces
{
    public interface IUserAccessor
    {
        Task<User> GetUserByUserIdAsync(int userId);
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByEmailAsync(string email);
        Task<User> AddUserAsync(User user);
    }
}
