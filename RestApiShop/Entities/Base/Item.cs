namespace RestApiShop.Entities.Base
{
    public abstract class Item : BaseEntity
    {
        public Shop Shop { get; set; }
        public int ShopId { get; set; }

    }
}
