using EcommerceWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebsite.Db
{
    public class ApplicationProductSizeContext : DbContext
    {
        public ApplicationProductSizeContext(DbContextOptions<ApplicationProductSizeContext> options) : base(options) { 
        
        }

        public DbSet<ProductSizeModel> ProductSizes { get; set; }

    }


}
