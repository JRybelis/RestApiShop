using System.Collections.Generic;
using Core.Entities.Base;
using Core.Entities.Relational;
using Core.Entities.ShopItems;

namespace Core.Entities
{
    public class Shop : BaseEntity
    {
        public List<Crockery> CrockeryItems { get; set; }
        public List<Fruit> Fruits { get; set; }
        public List<Vegetable> Vegetables { get; set; }
        public List<ShopOwnerShop> ShopOwners { get; set; }
    }
}
