using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.Base
{
    public abstract class ObjectDto
    {
        [MaxLength(51)] public string Name { get; set; }
    }
}
