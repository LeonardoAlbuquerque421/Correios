using System.Threading;
using CorreiosSpecFlow.Features.StepDefinitions.CorreiosPageDefinitions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace CorreiosSpecFlow.Features.StepDefinitions.CorreiosStepDefinitions
{
    [Binding]
    public class CorreiosSteps : CorreiosPage
    {
        private IWebDriver driver;

        [BeforeScenario]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void Teardown()
        {
            driver.Quit();
        }

        [Given(@"I am on the Correios website")]
        public void GivenIAmOnTheCorreiosWebsite()
        {
            driver.Navigate().GoToUrl("https://www.correios.com.br/");
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("#btnCookie")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.CssSelector("#pausa-card")).Click();
        }

        [When(@"I search for the CEP (.*)")]
        public void WhenISearchForTheCEP(string cep)
        {
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("#relaxation")).SendKeys(cep);
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("div.card.card-mais-acessados.ordem:nth-child(4) form:nth-child(1) div.campo:nth-child(3) > button.bt-link-ic:nth-child(2)")).Click();
        }

        [Then(@"I confirm that the CEP does not exist")]
        public void ThenIConfirmThatTheCEPDoesNotExist()
        {
            Thread.Sleep(2000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Assert.AreEqual("Dados não encontrado", driver.FindElement(By.CssSelector("h6:nth-child(1)")).Text);
        }

        [When(@"I search for the tracking code (.*)")]
        public void WhenISearchForTheTrackingCode(string trackingCode)
        {
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("#objetos")).SendKeys(trackingCode);
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("div.card.card-mais-acessados.ordem:nth-child(1) form:nth-child(1) div.campo:nth-child(3) > button.bt-link-ic:nth-child(2)")).Click();
        }

        [Then(@"I confirm that the code is not correct")]
        public void ThenIConfirmThatTheCodeIsNotCorrect()
        {
            Thread.Sleep(2000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Assert.AreEqual("Rastreamento", driver.FindElement(By.CssSelector("h3:nth-child(1)")).Text);
        }

        [Then(@"I confirm that the result is ""(.*)""")]
        public void ThenIConfirmThatTheResultIs(string expectedResult)
        {
            Thread.Sleep(2000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Assert.AreEqual(expectedResult, driver.FindElement(By.CssSelector("td:nth-child(1)")).Text);
        }
    }
}
