using ApiCotacao.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiCotacao.Repositories
{
    public class CotacaoRepository : ICotacaoRepository
    {
        public readonly CotacaoContext _context;

        public CotacaoRepository(CotacaoContext context)
        {
            _context = context;
        }

        public async Task<Cotacao> Create(Cotacao cotacao)
        {
            _context.Cotacoes.Add(cotacao);
            await _context.SaveChangesAsync();

            return cotacao;
        }

        public async Task Delete(int id)
        {
            var cotacaoToDelete = await _context.Cotacoes.FindAsync(id);
            _context.Cotacoes.Remove(cotacaoToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cotacao>> Get()
        {
            return await _context.Cotacoes.ToListAsync();
        }

        public async Task<Cotacao> Get(int id)
        {
            return await _context.Cotacoes.FindAsync(id);
        }

        public async Task<Cotacao> Get(string moedaBase, string moedaAlvo)
        {
            return await _context.Cotacoes.FirstOrDefaultAsync(item => item.MoedaBase == moedaBase && item.MoedaAlvo == moedaAlvo);
        }


        public async Task Update(Cotacao cotacao)
        {
            _context.Entry(cotacao).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
