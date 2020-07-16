using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace R_PROPERTY.Models
{
    public class inquiry
    {
        [Key]
        public int inquiry_id { get; set; }
        public int user_id { get; set; }
        public user_details user_details { get; set; }
        public int property_id { get; set; }
        public property_details property_Details { get; set; }
        public string user_massege { get; set; }
        public DateTime dateTime_inquiry { get; set; }
    }
}
