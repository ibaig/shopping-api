using AutoMapper;
using Shopping.Api.Domain.Models;
using Shopping.Api.Dtos;
using System;

namespace Shopping.Api.Mappings
{
    public static class AutomapperMappings
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg => {

                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<Product, ProductDto>();
                cfg.CreateMap<Specials, SpecialsDto>();
                cfg.CreateMap<ProductQuantity, ProductQuantityDto>();

            });
          

        }
    }
}
