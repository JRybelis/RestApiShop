using System.ComponentModel.DataAnnotations;

namespace RestApiShop.Dtos.Fruit
{
    public class FruitDto
    {
        [MaxLength(51)]
        public string Name { get; set; }
        public int ShopId { get; set; }
    }
}
