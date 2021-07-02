using System.ComponentModel.DataAnnotations;
using RestApiShop.Dtos.Base;

namespace RestApiShop.Dtos.Shop
{
    public class ShopPutDto : DtoObject
    {
        [Key] public int? Id { get; set; }
    }
}
