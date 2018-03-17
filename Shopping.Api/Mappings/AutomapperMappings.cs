using AutoMapper;
using Shopping.Api.Domain.Models;
using Shopping.Api.Dtos;

namespace Shopping.Api.Mappings
{
    public static class AutomapperMappings
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<User, UserDto>());
        }
    }
}
