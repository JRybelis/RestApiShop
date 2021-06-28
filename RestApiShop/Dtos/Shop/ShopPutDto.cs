using System.ComponentModel.DataAnnotations;

namespace RestApiShop.Dtos.Shop
{
    public class ShopPutDto
    {
        [Key] public int Id { get; set; }
        [MaxLength(51)] public string Name { get; set; }
    }
}
