using AutoMapper;
using RestApiShop.Dtos;
using RestApiShop.Dtos.Base;
using RestApiShop.Dtos.Crockery;
using RestApiShop.Dtos.Fruit;
using RestApiShop.Dtos.Shop;
using RestApiShop.Dtos.Vegetable;
using RestApiShop.Entities;
using RestApiShop.Entities.Base;

namespace RestApiShop.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<CrockeryDto, Crockery>().ReverseMap();
            CreateMap<FruitDto, Fruit>().ReverseMap();
            CreateMap<VegetableDto, Vegetable>().ReverseMap();
            CreateMap<ShopItemDto, Item>().ReverseMap();
            CreateMap<ShopDto, Shop>().ReverseMap();
        }
    }
}
