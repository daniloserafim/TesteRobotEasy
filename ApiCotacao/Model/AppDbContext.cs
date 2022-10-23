using Microsoft.EntityFrameworkCore;

namespace ApiCotacao.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Cotacao> Cotacoes { get; set; }
    }
}
