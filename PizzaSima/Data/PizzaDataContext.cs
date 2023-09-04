using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PizzaSima.Models;

namespace PizzaSima.Data
{
    public class PizzaDataContext : IdentityDbContext
    {
        public PizzaDataContext(DbContextOptions<PizzaDataContext> options) : base(options)
        {
        }
        public DbSet<Pizza> PizzaSimas { get; set; }
        public DbSet<PizzaOrder> PizzaOrders { get; set;}
    }
}
