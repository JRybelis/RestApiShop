using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiShop.Dtos
{
    public class CrockeryDto
    {
        [MaxLength(51)]
        public string Name { get; set; }
        public int ShopId { get; set; }
    }
}
