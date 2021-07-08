using System.ComponentModel.DataAnnotations;
using RestApiShop.Dtos.Base;

namespace RestApiShop.Dtos.Shop
{
    public class ShopDto : ObjectDto
    {
        [Key] public int? Id { get; set; }
    }
    
}
