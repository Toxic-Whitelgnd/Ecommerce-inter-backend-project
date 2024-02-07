using EcommerceWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebsite.Db
{
    public class ApplicationItemsOrderContext : DbContext
    {
        public ApplicationItemsOrderContext(DbContextOptions<ApplicationItemsOrderContext> options ) : base (options)
        {
        }

        public DbSet<ItemsOrderedModel> ItemsOrderedTables { get; set; }
    }
}
