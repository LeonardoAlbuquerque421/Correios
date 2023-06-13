using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using CorreiosSpecFlow.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow.Analytics;

namespace CorreiosSpecFlow.ActionDefinitions
{
    public class CorreiosAction
    {
        private IWebDriver driver;

        CorreiosPage correiosPage = new CorreiosPage();

        public CorreiosAction(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void clickCookieSiteCorreiosAction()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until((drv) => driver.FindElement(correiosPage.btnCookie).Displayed);
            driver.FindElement(correiosPage.btnCookie).Click();
            wait.Until((drv) => driver.FindElement(correiosPage.btnPausaCard).Displayed);
            driver.FindElement(correiosPage.btnPausaCard).Click();
        }

        public void setISearchForTheCEP(string cep)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.FindElement(correiosPage.searchCep).SendKeys(cep);
            wait.Until((drv) => driver.FindElement(correiosPage.searchCep).Displayed);
            driver.FindElement(correiosPage.btnSearchCep).Click();
        }

        public void validateIConfirmThatTheCEPDoesNotExist()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.SwitchTo().Window(driver.WindowHandles.Last());
            wait.Until((drv) => driver.FindElement(By.CssSelector("h6:nth-child(1)")).Displayed);
            Assert.AreEqual("Dados não encontrado", driver.FindElement(By.CssSelector("h6:nth-child(1)")).Text);
        }

        public void setISearchForTheTrackingCode(string trackingCode)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until((drv) => driver.FindElement(By.CssSelector("#objetos")).Displayed);
            driver.FindElement(By.CssSelector("#objetos")).SendKeys(trackingCode);
            driver.FindElement(By.CssSelector("div.card.card-mais-acessados.ordem:nth-child(1) form:nth-child(1) div.campo:nth-child(3) > button.bt-link-ic:nth-child(2)")).Click();
        }

        public void validateIConfirmThatTheCodeIsNotCorrect()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.SwitchTo().Window(driver.WindowHandles.Last());
            wait.Until((drv) => driver.FindElement(By.CssSelector("h3:nth-child(1)")).Displayed);
            Assert.AreEqual("Rastreamento", driver.FindElement(By.CssSelector("h3:nth-child(1)")).Text);
        }

        public void validateIConfirmThatTheResultIs(string expectedResult)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.SwitchTo().Window(driver.WindowHandles.Last());
            wait.Until((drv) => driver.FindElement(By.CssSelector("td:nth-child(1)")).Displayed);
            Assert.AreEqual(expectedResult, driver.FindElement(By.CssSelector("td:nth-child(1)")).Text);
        }
    }
}
