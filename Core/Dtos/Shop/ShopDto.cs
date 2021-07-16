using System.ComponentModel.DataAnnotations;
using Core.Dtos.Base;

namespace Core.Dtos.Shop
{
    public class ShopDto : ObjectDto
    {
        [Key] public int? Id { get; set; }
    }
    
}
