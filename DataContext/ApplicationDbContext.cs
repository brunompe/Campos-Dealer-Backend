using Campos_Dealer_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Campos_Dealer_Backend.DataContext
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }

        public DbSet<CustomerModel> Customers { get; set; }
    }
}
