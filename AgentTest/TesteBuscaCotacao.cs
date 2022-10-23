using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ApiCotacao.Libraries;

namespace ApiUnitTest
{
    public class TesteBuscaCotacao
    {
        public IWebDriver driver;
        public string moedaBase = "EUR";
        public string moedaAlvo = "BRL";

        [Test]
        public void GetCOtacaoSeleniumTest()
        {
            CotacaoUseCases useCase = new CotacaoUseCases();
            string cotacao = useCase.GetCotacaoSelenium(moedaBase, moedaAlvo);
            Assert.True(!string.IsNullOrEmpty(cotacao));
        }
    }
}