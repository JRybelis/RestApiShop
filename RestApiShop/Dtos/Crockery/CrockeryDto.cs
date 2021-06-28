using System.ComponentModel.DataAnnotations;

namespace RestApiShop.Dtos.Crockery
{
    public class CrockeryDto
    {
        [MaxLength(51)]
        public string Name { get; set; }
        public int ShopId { get; set; }
    }
}
