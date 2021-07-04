using System.ComponentModel.DataAnnotations;
using RestApiShop.Dtos.Base;

namespace RestApiShop.Dtos.Crockery
{
    public class CrockeryDto : DtoShopItem
    {
        [Key] public int? Id { get; set; }
    }
}
