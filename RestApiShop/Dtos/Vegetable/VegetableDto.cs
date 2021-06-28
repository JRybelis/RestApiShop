using System.ComponentModel.DataAnnotations;

namespace RestApiShop.Dtos.Vegetable
{
    public class VegetableDto
    {
        [MaxLength(51)]
        public string Name { get; set; }
        public int ShopId { get; set; }
    }
}
