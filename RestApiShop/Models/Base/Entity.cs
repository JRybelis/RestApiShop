using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiShop.Models.Base
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(51)]
        public string Name { get; set; }

        public bool Deleted { get; set; } = false;
    }
}
