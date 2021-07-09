using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestApiShop.Entities.Relational;

namespace RestApiShop.Entities
{
    public class ShopOwner
    {
        public int  Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public List<ShopOwnerShop> Shops { get; set; }
    }
}
