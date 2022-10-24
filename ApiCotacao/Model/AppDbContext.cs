using Microsoft.EntityFrameworkCore;

namespace ApiCotacao.Model
{
    public class CotacaoContext : DbContext
    {
        public CotacaoContext(DbContextOptions<CotacaoContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Cotacao> Cotacoes { get; set; }
    }
}
