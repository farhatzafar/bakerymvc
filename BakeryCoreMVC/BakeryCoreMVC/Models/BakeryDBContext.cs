using Microsoft.EntityFrameworkCore;

namespace BakeryCoreMVC.Models
{
    public class BakeryDBContext : DbContext
    {
        public BakeryDBContext(DbContextOptions<BakeryDBContext> options)
            : base(options)
        { }

        // DbSet for BakeryItems
        public DbSet<BakeryItem> BakeryItems { get; set; }
    }
}
