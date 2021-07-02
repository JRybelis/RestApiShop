using System.ComponentModel.DataAnnotations;
using RestApiShop.Dtos.Base;

namespace RestApiShop.Dtos.Fruit
{
    public class FruitPutDto : DtoShopItem
    {
        [Key] public int Id { get; set; }
    }
}
