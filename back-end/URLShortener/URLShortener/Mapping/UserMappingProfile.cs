using AutoMapper;
using URLShortener.DTOs;
using URLShortener.Models;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserDto>();
    }
}
