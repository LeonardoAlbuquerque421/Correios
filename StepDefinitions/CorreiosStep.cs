using System.Reflection;
using System.Threading;
using CorreiosSpecFlow.ActionDefinitions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace CorreiosSpecFlow.Steps
{
    [Binding]
    public class CorreiosStep
    {
        private IWebDriver driver;

        [BeforeScenario]
        public void Setup()
        {
            // Obtém o caminho da pasta do projeto
            var projetoPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            // Define o caminho completo para o chromedriver
            var chromedriverPath = Path.Combine(projetoPath, "drivers", "chromedriver.exe");

            driver = new ChromeDriver(chromedriverPath);
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
            CorreiosAction correiosAction = new CorreiosAction(driver);

            driver.Navigate().GoToUrl("https://www.correios.com.br/");
            correiosAction.clickCookieSiteCorreiosAction();
        }

        [When(@"I search for the CEP (.*)")]
        public void WhenISearchForTheCEP(string cep)
        {
            CorreiosAction correiosAction = new CorreiosAction(driver);
            correiosAction.setISearchForTheCEP(cep);
        }

        [Then(@"I confirm that the CEP does not exist")]
        public void ThenIConfirmThatTheCEPDoesNotExist()
        {
            CorreiosAction correiosAction = new CorreiosAction(driver);
            correiosAction.validateIConfirmThatTheCEPDoesNotExist();
        }

        [When(@"I search for the tracking code (.*)")]
        public void WhenISearchForTheTrackingCode(string trackingCode)
        {
            CorreiosAction correiosAction = new CorreiosAction(driver);
            correiosAction.setISearchForTheTrackingCode(trackingCode);
        }

        [Then(@"I confirm that the code is not correct")]
        public void ThenIConfirmThatTheCodeIsNotCorrect()
        {
            CorreiosAction correiosAction = new CorreiosAction(driver);
            correiosAction.validateIConfirmThatTheCodeIsNotCorrect();
        }

        [Then(@"I confirm that the result is ""(.*)""")]
        public void ThenIConfirmThatTheResultIs(string expectedResult)
        {
            CorreiosAction correiosAction = new CorreiosAction(driver);
            correiosAction.validateIConfirmThatTheResultIs(expectedResult);
        }
    }
}
