using System.Collections.Generic;
using Core.Entities.ShopItems;

namespace RestApiShop.Data
{
    public class DataService
    {
        public List<Crockery> CrockeryPieces { get; set; } = new();
        public List<Fruit> Fruits { get; set; } = new();
        public List<Vegetable> Vegetables { get; set; } = new();
    }
}