using System.ComponentModel.DataAnnotations;

namespace RestApiShop.Dtos.Base
{
    public class DtoObject
    {
        [MaxLength(51)] public string Name { get; set; }
    }
}
