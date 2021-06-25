using AutoMapper;
using RestApiShop.Dtos;
using RestApiShop.Entities;

namespace RestApiShop.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<CrockeryDto, Crockery>().ReverseMap();
            CreateMap<FruitDto, Fruit>().ReverseMap();
            CreateMap<VegetableDto, Vegetable>().ReverseMap();
        }
    }
}
