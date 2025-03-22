using AutoMapper;
using URLShortener.DTOs;
using URLShortener.Models;

namespace URLShortener.Mapping
{
    public class UrlMappingProfile : Profile
    {
        public UrlMappingProfile()
        {
            CreateMap<UrlShortener, FullUrlInfoDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.UserId))
                .ForMember(dest => dest.AuthorUsername, opt => opt.MapFrom(src => src.User.Username))
                .ForMember(dest => dest.AuthorEmail, opt => opt.MapFrom(src => src.User.Email));

            CreateMap<UrlShortener, UrlDto>();
        }
    }
}
