using AutoMapper;
using Microsoft.EntityFrameworkCore;
using URLShortener.Accessors.Interfaces;
using URLShortener.DTOs;
using URLShortener.Enums;
using URLShortener.Managers.Interfaces;
using URLShortener.Models;

namespace URLShortener.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserAccessor _userAccessor;
        private readonly IMapper _mapper;

        public UserManager(IUserAccessor userAccessor)
        {
            _userAccessor = userAccessor;
        }

        public async Task<User> RegisterUserAsync(string username, string email, string password)
        {
            var existingUser = await _userAccessor.GetUserByEmailAsync(email);

            if (existingUser != null)
                return null;

            var newUser = new User
            {
                Username = username,
                Email = email,
                Password = password,
                Role = UserRoleEnum.User
            };

            var createdUser = await _userAccessor.AddUserAsync(newUser);

            return createdUser;
        }

        public async Task<User> AuthenticateUserAsync(string email, string password)
        {
            var user = await _userAccessor.GetUserByEmailAsync(email);

            if (user == null || user.Password != password)
                return null;

            return user;
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _userAccessor.GetAllUsersAsync();
            return _mapper.Map<List<UserDto>>(users);
        }
    }
}
