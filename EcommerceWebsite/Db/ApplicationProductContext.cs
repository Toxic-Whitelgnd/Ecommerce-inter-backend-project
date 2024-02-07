using EcommerceWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebsite.Db
{
    public class ApplicationProductContext : DbContext
    {
        public DbSet<Product> ProductTables { get; set; }

        public ApplicationProductContext(DbContextOptions<ApplicationProductContext> options ) : base(options) { 
        
        }
    }
}
