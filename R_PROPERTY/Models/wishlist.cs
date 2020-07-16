using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace R_PROPERTY.Models
{
    public class wishlist
    {
        [Key]
        public int wishlist_id { get; set; }
        public int user_id { get; set; }
        public int property_id { get; set; }
    }
}
