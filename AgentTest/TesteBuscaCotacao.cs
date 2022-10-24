using ApiCotacao.Libraries;

namespace ApiUnitTest
{
    public class TesteBuscaCotacao
    {
        public string moedaBase = "EUR";
        public string moedaAlvo = "BRL";

        [Test]
        public void GetCotacaoSeleniumTest()
        {
            string cotacao = CotacaoUseCases.GetCotacaoSelenium(moedaBase, moedaAlvo);
            Assert.True(!string.IsNullOrEmpty(cotacao));
        }
    }
}