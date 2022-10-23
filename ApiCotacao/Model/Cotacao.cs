using Microsoft.EntityFrameworkCore;

namespace ApiCotacao.Model
{
    public class Cotacao
    {
        public int id { get; set; }
        public string moedaBase { get; set; }
        public string moedaAlvo { get; set; }
        public String valor { get; set; }

        //public string? GetEntry(string moedaBase, string moedaAlvo)
        //{
        //    Task<Cotacao> tes = async (AppDbContext dbContext) => await dbContext.Cotacoes.ToListAsync();

        //    var result = async (AppDbContext dbContext) => {
        //        await dbContext.Cotacoes.ToListAsync();
        //    };

        //    var teste = result.Invoke;
        //    //return result.valor.ToString();
        //    return result.ToString();
        //}

        //public static void Insert(string moedaBase, string moedaAlvo, string valor)
        //{
        //    async (Cotacao cotacao, AppDbContext dbContext) => {
        //        dbContext.Cotacoes.Add(cotacao);
        //        await dbContext.SaveChangesAsync();
        //    });
        //}
    }
}
