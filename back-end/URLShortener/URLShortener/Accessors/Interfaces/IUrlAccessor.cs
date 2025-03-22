using URLShortener.DTOs;
using URLShortener.Models;

namespace URLShortener.Accessors.Interfaces
{
    public interface IUrlAccessor
    {
        Task<FullUrlInfoDto> GetUrlDetailByShortenedAsync(int urlId);
        Task<List<UrlShortener>> GetUrlsByUserAsync(int userId);
        Task<UrlShortener> AddUrlAsync(UrlShortener url);
        Task<bool> DeleteUrlAsync(int id);
        Task<User> GetUserByUrlIdAsync(int urlId);
        Task<List<UrlShortener>> GetAllUrlsAsync();
    }
}
