using System.Collections.Generic;
using RestApiShop.Entities;

namespace RestApiShop.Data
{
    public class DataService
    {
        public List<Crockery> CrockeryPieces { get; set; }
        public List<Fruit> Fruits { get; set; }
        public List<Vegetable> Vegetables { get; set; }

        public DataService()
        {
            CrockeryPieces = new List<Crockery>();
            Fruits = new List<Fruit>();
            Vegetables = new List<Vegetable>();
        }
    }
}
