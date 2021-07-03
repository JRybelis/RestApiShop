using System.ComponentModel.DataAnnotations;

namespace RestApiShop.Entities.Base
{
    public abstract class BaseEntity
    {
        //[Key]
        public int Id { get; set; }
        
        //[MaxLength(51)]
        public string Name { get; set; }

        public bool Deleted { get; set; } = false;
    }
}
