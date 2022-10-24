namespace ApiCotacao.Model
{
    public class Cotacao
    {
        public int Id { get; set; }
        public string MoedaBase { get; set; }
        public string MoedaAlvo { get; set; }
        public string Data { get; set; }
        public String Valor { get; set; }
    }
}
