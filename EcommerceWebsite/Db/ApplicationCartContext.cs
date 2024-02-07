using EcommerceWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebsite.Db
{
    public class ApplicationCartContext : DbContext
    {
        public ApplicationCartContext(DbContextOptions<ApplicationCartContext>option ) : base(option)
        {

        }

        public DbSet<CartModel> CartTables { get; set; }
    }
}
