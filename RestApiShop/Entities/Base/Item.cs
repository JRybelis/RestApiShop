namespace RestApiShop.Entities.Base
{
    public abstract class Item : Entity
    {
        public Shop Shop { get; set; }
        public int ShopId { get; set; }

    }
}
