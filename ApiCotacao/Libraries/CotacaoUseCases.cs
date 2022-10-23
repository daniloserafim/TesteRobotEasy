using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ApiCotacao.Libraries
{
    public class CotacaoUseCases
    {
        public IWebDriver driver;
        public string cotacao;

        public string GetCotacaoSelenium(string moedaBase, string moedaAlvo)
        {
            try
            {
                driver = new ChromeDriver();
                driver.Navigate().GoToUrl("https://www.google.com/");
                driver.Manage().Window.Maximize();

                driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/input")).SendKeys("cotação " + moedaBase + " " + moedaAlvo);
                driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[4]/center/input[1]")).Click();
                cotacao = driver.FindElement(By.XPath("//*[@id='knowledge-currency__updatable-data-column']/div[1]/div[2]/span[1]")).Text;
                driver.Quit();
            } catch (Exception e)
            {
                cotacao = e.Message;
            }

            return cotacao;
        }
    }
}
