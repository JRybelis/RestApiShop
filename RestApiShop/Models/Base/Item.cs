using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiShop.Models.Base
{
    public abstract class Item : Entity
    {
        public Shop Shop { get; set; }
        public int ShopId { get; set; }

    }
}
