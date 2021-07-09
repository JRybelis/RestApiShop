using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiShop.Entities
{
    public class ShopOwner
    {
        public int  Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public int SingleShopId { get; set; }
    }
}
