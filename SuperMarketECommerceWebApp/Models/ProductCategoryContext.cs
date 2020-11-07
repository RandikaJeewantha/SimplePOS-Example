using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketECommerceWebApp.Models
{
    public class ProductCategoryContext:DbContext
    {
        public ProductCategoryContext(DbContextOptions<ProductCategoryContext> options):base(options)
        {

        }

        public DbSet<ProductCatagory> ProductCatagories { get; set; }
    }
}
