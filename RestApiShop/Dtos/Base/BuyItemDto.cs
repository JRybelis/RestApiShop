using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiShop.Dtos.Base
{
    public class BuyItemDto
    {
        public string ItemName { get; set; }
        public int Quantity { get; set; }
    }
}
