using ApiCotacao.Model;

namespace ApiCotacao.Repositories
{
    public interface ICotacaoRepository
    {
        Task<IEnumerable<Cotacao>> Get();
        Task<Cotacao> Get(int Id);
        Task<Cotacao> Get(string moedaBase, string moedaAlvo);
        Task<Cotacao> Create(Cotacao cotacao);
        Task Update(Cotacao cotacao);
        Task Delete(int Id);
    }
}
