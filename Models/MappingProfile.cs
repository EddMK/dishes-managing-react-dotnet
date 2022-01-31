using System;
using AutoMapper;
namespace Models{
    public class MappingProfile : Profile {
        public MappingProfile() {
            // Add as many of these lines as you need to map your objects
            CreateMap<Dish, DishDto>();
            CreateMap<DishDto, Dish>();
        }
    }
}