using Microsoft.EntityFrameworkCore;
using URLShortener.Accessors.Interfaces;
using URLShortener.Data;
using URLShortener.Models;

namespace URLShortener.Accessors
{
    public class UserAccessor : IUserAccessor
    {
        private readonly ApplicationDbContext _context;

        public UserAccessor(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> GetUserByUserIdAsync(int userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        }
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task<User> AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

    }
}
