using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using URLShortener.Accessors.Interfaces;
using URLShortener.Data;
using URLShortener.DTOs;
using URLShortener.Models;

namespace URLShortener.Accessors
{
    public class UrlAccessor : IUrlAccessor
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UrlAccessor(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<FullUrlInfoDto> GetUrlDetailByShortenedAsync(int urlId)
        {
            var url = await _context.Urls
                .Include(u => u.User)
                .FirstOrDefaultAsync(u => u.Id == urlId);

            return _mapper.Map<FullUrlInfoDto>(url);
        }
        public async Task<User> GetUserByUrlIdAsync(int urlId)
        {
            var url = await _context.Urls.FirstOrDefaultAsync(u => u.Id == urlId);

            if (url == null)
                return null;

            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == url.UserId);

            return user;
        }


        public async Task<List<UrlShortener>> GetUrlsByUserAsync(int userId)
        {
            return await _context.Urls.Where(u => u.UserId == userId).ToListAsync();
        }

        public async Task<UrlShortener> AddUrlAsync(UrlShortener url)
        {
            await _context.Urls.AddAsync(url);
            await _context.SaveChangesAsync();
            return url;
        }

        public async Task<bool> DeleteUrlAsync(int id)
        {
            var url = await _context.Urls.FindAsync(id);
            if (url == null)
                return false;

            _context.Urls.Remove(url);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<UrlShortener>> GetAllUrlsAsync()
        {
            return await _context.Urls.ToListAsync();
        }
    }
}
