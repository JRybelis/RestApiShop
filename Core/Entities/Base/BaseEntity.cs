namespace Core.Entities.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public bool Deleted { get; set; } = false;
    }
}
