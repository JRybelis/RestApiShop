using System.ComponentModel.DataAnnotations;
using RestApiShop.Dtos.Base;

namespace RestApiShop.Dtos.Vegetable
{
    public class VegetableDto : DtoShopItem
    {
        [Key] public int? Id { get; set; }   
    }
}
