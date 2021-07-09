using System.Collections.Generic;
using RestApiShop.Entities.Base;
using RestApiShop.Entities.Relational;
using RestApiShop.Entities.ShopItems;

namespace RestApiShop.Entities
{
    public class Shop : BaseEntity
    {
        public List<Crockery> CrockeryItems { get; set; }
        public List<Fruit> Fruits { get; set; }
        public List<Vegetable> Vegetables { get; set; }
        public List<ShopOwnerShop> ShopOwners { get; set; }
    }
}
