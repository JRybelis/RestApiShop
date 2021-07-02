using System.ComponentModel.DataAnnotations;
using RestApiShop.Dtos.Base;

namespace RestApiShop.Dtos.Crockery
{
    public class CrockeryPutDto: DtoShopItem
    {
        [Key] public int? Id { get; set; }
    }
}
