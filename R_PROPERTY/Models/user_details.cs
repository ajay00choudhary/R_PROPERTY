using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace R_PROPERTY.Models
{
    public class user_details
    {
        [Key]
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string user_phone_number { get; set; }
        public string user_address { get; set; }
        public string user_email { get; set; }
    }
}
