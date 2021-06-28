using System.ComponentModel.DataAnnotations;

namespace RestApiShop.Dtos.Vegetable
{
    public class VegetablePutDto
    {
        [Key] 
        public int Id { get; set; }
        
        [MaxLength(51)]
        public string Name { get; set; }

        public int ShopId { get; set; }
    }
}
