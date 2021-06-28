using System.ComponentModel.DataAnnotations;

namespace RestApiShop.Dtos.Fruit
{
    public class FruitPutDto
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(51)]
        public string Name { get; set; }
        public int ShopId { get; set; }
    }
}
