namespace ApiCotacao.Model
{
    public class CotacaoRequest
    {
        public string moedaBase { get; set; }
        public string moedaAlvo { get; set; }
        public Decimal valor { get; set; }
    }
}
