using System.ComponentModel.DataAnnotations;

namespace RestApiShop.Dtos.Crockery
{
    public class CrockeryPutDto
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(51)] 
        public string Name { get; set; }

        public int ShopId { get; set; }

    }
}
