using AutoMapper;
using RestApiShop.Dtos;
using RestApiShop.Dtos.Crockery;
using RestApiShop.Dtos.Fruit;
using RestApiShop.Dtos.Shop;
using RestApiShop.Dtos.Vegetable;
using RestApiShop.Entities;

namespace RestApiShop.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<CrockeryDto, Crockery>().ReverseMap();
            CreateMap<CrockeryPutDto, Crockery>().ReverseMap();
            CreateMap<FruitDto, Fruit>().ReverseMap();
            CreateMap<FruitPutDto, Fruit>().ReverseMap();
            CreateMap<VegetableDto, Vegetable>().ReverseMap();
            CreateMap<VegetablePutDto, Vegetable>().ReverseMap();
            CreateMap<ShopDto, Shop>().ReverseMap();
            CreateMap<ShopPutDto, Shop>().ReverseMap();
        }
    }
}
