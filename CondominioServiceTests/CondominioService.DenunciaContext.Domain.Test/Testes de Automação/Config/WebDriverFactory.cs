using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioService.DenunciaContext.Domain.Test.Testes_Automatizados
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver(string caminhoDriver, bool headless)
        {
            IWebDriver webDriver = null;

            var options = new ChromeOptions();
            if (headless)
                options.AddArgument("--headless");

            webDriver = new ChromeDriver(caminhoDriver, options);

            return webDriver;
        }
    }
}
