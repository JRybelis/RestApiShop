using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.Base
{
    public abstract class ShopItemDto : ObjectDto
    {
        public int ShopId { get; set; }
        public decimal? Price { get; set; }
        [Key] public int? Id { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
    }
}
