using EcommerceWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebsite.Db
{
    public class ApplicationUsercontext :DbContext
    {
        public ApplicationUsercontext(DbContextOptions<ApplicationUsercontext>options) : base(options)
        {

        }

    public DbSet<UserModel> userdetails { get; set; }
    }
}
