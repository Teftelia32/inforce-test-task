using System;
using URLShortener.DTOs;
using URLShortener.Models;

namespace URLShortener.Managers.Interfaces
{
    public interface IUrlManager
    {
        Task<FullUrlInfoDto> GetUrlDetailsAsync(int urlId);
        Task<List<UrlDto>> GetUrlsByUserAsync(int userId);
        Task<UrlDto> CreateUrlAsync(string originalUrl, int userId);
        Task<bool> DeleteUrlAsync(int id, int userId);
        Task<List<UrlDto>> GetAllUrlsAsync();
    }
}
