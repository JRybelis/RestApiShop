using System.ComponentModel.DataAnnotations;

namespace RestApiShop.Dtos.Base
{
    public abstract class ShopItemDto : DtoObject
    {
        public int ShopId { get; set; }
        public decimal? Price { get; set; }
        [Key] public int? Id { get; set; }
    }
}
