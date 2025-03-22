using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using URLShortener.Accessors.Interfaces;
using URLShortener.DTOs;
using URLShortener.Enums;
using URLShortener.Managers.Interfaces;
using URLShortener.Models;

namespace URLShortener.Managers
{
    public class UrlManager : IUrlManager
    {
        private readonly IUrlAccessor _urlAccessor;
        private readonly IUserAccessor _userAccessor;
        private readonly IMapper _mapper;

        public UrlManager(IUrlAccessor urlAccessor, IUserAccessor userAccessor, IMapper mapper)
        {
            _urlAccessor = urlAccessor;
            _userAccessor = userAccessor;
            _mapper = mapper;
        }

        public async Task<FullUrlInfoDto> GetUrlDetailsAsync(int urlId)
        {
            return await _urlAccessor.GetUrlDetailByShortenedAsync(urlId);
        }

        public async Task<List<UrlDto>> GetUrlsByUserAsync(int userId)
        {
            var urls = await _urlAccessor.GetUrlsByUserAsync(userId);
            return _mapper.Map<List<UrlDto>>(urls);
        }

        public async Task<UrlDto> CreateUrlAsync(string originalUrl, int userId)
        {
            var shortenedUrl = GenerateShortenedUrl(originalUrl);

            var url = new UrlShortener
            {
                OriginalUrl = originalUrl,
                ShortenedUrl = shortenedUrl,
                UserId = userId,
                CreatedAt = DateTime.UtcNow
            };

            var createdUrl = await _urlAccessor.AddUrlAsync(url);
            return _mapper.Map<UrlDto>(createdUrl);
        }

        public async Task<bool> DeleteUrlAsync(int id, int userId)
        {
            var urlCreator = await _urlAccessor.GetUserByUrlIdAsync(id);
            var user = await _userAccessor.GetUserByUserIdAsync(userId);


            if (urlCreator == null || urlCreator.UserId != userId && user.Role != UserRoleEnum.Admin)
                return false;

            return await _urlAccessor.DeleteUrlAsync(id);
        }
        public async Task<List<UrlDto>> GetAllUrlsAsync()
        {
            var urls = await _urlAccessor.GetAllUrlsAsync();
            return _mapper.Map<List<UrlDto>>(urls);
        }

        private string GenerateShortenedUrl(string originalUrl)
        {
            var guidPart = Guid.NewGuid().ToString("N").Substring(0, 8);

            var urlHash = originalUrl.GetHashCode().ToString("X");

            return $"{guidPart}{urlHash.Substring(0, 4)}";
        }

    }
}
