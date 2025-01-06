using AdventureApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdventureApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options) 
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
