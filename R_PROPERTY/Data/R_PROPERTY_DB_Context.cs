using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using R_PROPERTY.Models;

namespace R_PROPERTY.Data
{
    public class R_PROPERTY_DB_Context : DbContext
    {
        public R_PROPERTY_DB_Context (DbContextOptions<R_PROPERTY_DB_Context> options)
            : base(options)
        {
        }

        public DbSet<R_PROPERTY.Models.inquiry> inquiry { get; set; }

        public DbSet<R_PROPERTY.Models.property_details> property_details { get; set; }

        public DbSet<R_PROPERTY.Models.user_details> user_details { get; set; }

        public DbSet<R_PROPERTY.Models.wishlist> wishlist { get; set; }
    }
}
