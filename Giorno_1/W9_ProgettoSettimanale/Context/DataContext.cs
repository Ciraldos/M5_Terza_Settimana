using Microsoft.EntityFrameworkCore;
using W9_ProgettoSettimanale.Models;

namespace W9_ProgettoSettimanale.Context
{
    public class DataContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }

        public DataContext(DbContextOptions<DataContext> opt) : base(opt) { }
    }
}
