using AutoMapper;
using GigHub.Controllers.Api;
using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Genre, GenreDto>().ReverseMap();
                cfg.CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap();
                cfg.CreateMap<Gig, GigDto>().ReverseMap();
                cfg.CreateMap<Notification, NotificationDto>().ReverseMap();
            });
        }
    }
}