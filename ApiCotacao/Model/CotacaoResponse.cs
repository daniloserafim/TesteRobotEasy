namespace ApiCotacao.Model
{
    public class CotacaoResponse
    {
        public string moedaBase { get; set; }
        public string moedaAlvo { get; set; }
        public DateTime data { get; set; }
        public string valor { get; set; }
    }
}
