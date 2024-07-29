using Microsoft.EntityFrameworkCore;

namespace W9.D1.EntityFramework.DataModel
{
    /// <summary>
    /// Contesto applicativo di gestione della persistenza su database.
    /// </summary>
    public class BlogDbContext : DbContext
    {
        /// <summary>
        /// Riferimento alla tabella degli articoli sul db.
        /// </summary>
        public virtual DbSet<Article> Articles { get; set; }
        /// <summary>
        /// Riferimento alla tabella degli autori sul db.
        /// </summary>
        public virtual DbSet<Author> Authors { get; set; }

        public BlogDbContext(
            // opzioni di configurazione ottenute tramite DI
            DbContextOptions<BlogDbContext> options)
            : base(options) { }
    }
}
