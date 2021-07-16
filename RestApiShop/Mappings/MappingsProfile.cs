using AutoMapper;
using Core.Dtos.Base;
using Core.Dtos.Crockery;
using Core.Dtos.Fruit;
using Core.Dtos.Shop;
using Core.Dtos.Vegetable;
using Core.Entities;
using Core.Entities.Base;
using Core.Entities.ShopItems;

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
