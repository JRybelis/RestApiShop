namespace Core.Entities.Base
{
    public class Item : BaseEntity
    {
        public Shop Shop { get; set; }
        public int ShopId { get; set; }
        public decimal Price { get; set; } = 3.5M;
        public string Type { get; set; }
        public int Quantity { get; set; } = 1;

    }
}
