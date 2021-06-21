using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestApiShop.Models;

namespace RestApiShop.Data
{
    public class DataService
    {
        public List<Crockery> CrockeryPieces { get; set; }
        public List<Fruit> Fruits { get; set; }
        public List<Vegetable> Vegetables { get; set; }

        public DataService(List<Crockery> crockeryPieces, List<Fruit> fruits, List<Vegetable> vegetables)
        {
            CrockeryPieces = crockeryPieces;
            Fruits = fruits;
            Vegetables = vegetables;
        }
    }
}
