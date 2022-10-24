using ApiCotacao.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ApiCotacao.Libraries
{
    public class CotacaoUseCases
    {
        public static string GetCotacaoSelenium(string moedaBase, string moedaAlvo)
        {
            IWebDriver driver = new ChromeDriver();
            string cotacao;

            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Manage().Window.Maximize();

            try
            {
                driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/input")).SendKeys("cotação " + moedaBase + " " + moedaAlvo);
                driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[4]/center/input[1]")).Click();
                cotacao = driver.FindElement(By.XPath("//*[@id='knowledge-currency__updatable-data-column']/div[1]/div[2]/span[1]")).Text;
                driver.Quit();
            }
            catch (NoSuchElementException e)
            {
                driver.Quit();
                throw new Exception("Moedas inválidas!");
            }

            return cotacao;
        }

        public static Cotacao BuildCotacao(string moedaBase, string moedaAlvo, string valorCotacao)
        {
            Cotacao cotacao = new Cotacao();
            cotacao.MoedaBase = moedaBase;
            cotacao.MoedaAlvo = moedaAlvo;
            cotacao.Data = DateTime.Now.ToString("d/M/yy");
            cotacao.Valor = valorCotacao;

            return cotacao;
        }
    }
}
