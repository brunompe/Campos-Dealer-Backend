using Campos_Dealer_Backend.Models.Customer;
using Campos_Dealer_Backend.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace Campos_Dealer_Backend.DataContext
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }

        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<ProductModel> Products { get; set; }

    }
}
