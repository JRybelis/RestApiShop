namespace RestApiShop.Entities.Base
{
    public abstract class Item : BaseEntity
    {
        public Shop Shop { get; set; }
        public int ShopId { get; set; }
        public decimal Price { get; set; } = 3.5M;

    }
}
