using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow.Analytics;

namespace CorreiosSpecFlow.Page
{
    public class CorreiosPage
    {
        public By btnCookie = By.Id("btnCookie");
        public By btnPausaCard = By.CssSelector("#pausa-card");
        public By searchCep = By.CssSelector("#relaxation");
        public By btnSearchCep = By.CssSelector("div.card.card-mais-acessados.ordem:nth-child(4) form:nth-child(1) div.campo:nth-child(3) > button.bt-link-ic:nth-child(2)");
    }
}
