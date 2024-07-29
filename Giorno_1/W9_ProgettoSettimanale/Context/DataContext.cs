using Microsoft.EntityFrameworkCore;
using W9_ProgettoSettimanale.Models;

namespace W9_ProgettoSettimanale.Context
{
    public class DataContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }

        public virtual DbSet<Orders> Orders { get; set; }

        public virtual DbSet<Users> Users { get; set; }

        public virtual DbSet<Roles> Roles { get; set; }

        public virtual DbSet<OrderedProduct> OrderedProducts { get; set; }

        public DataContext(DbContextOptions<DataContext> opt) : base(opt) { }
    }
}
