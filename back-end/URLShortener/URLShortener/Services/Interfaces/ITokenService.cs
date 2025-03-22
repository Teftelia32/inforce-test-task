using URLShortener.Models;

namespace URLShortener.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateJwtToken(User user);
    }
}
