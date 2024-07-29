using DashboardProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DashboardProject.Data
{
    public class ApplicationDbContext : DbContext
    {
  
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


            public DbSet<Product> products { get; set; }


            public DbSet<ProductDetails> productsDetails { get; set; }


            public DbSet<DamagedProducts> damagedProduct { get; set; }

        }
    }


