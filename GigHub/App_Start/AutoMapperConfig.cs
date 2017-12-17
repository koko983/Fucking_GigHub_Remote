using AutoMapper;
using GigHub.Dtos;
using GigHub.Models;

namespace GigHub.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Genre, GenreDto>().ReverseMap();
                cfg.CreateMap<ApplicationUser, UserDto>().ReverseMap();
                cfg.CreateMap<Gig, GigDto>().ReverseMap();
                cfg.CreateMap<Notification, NotificationDto>().ReverseMap();
            });
        }
    }
}