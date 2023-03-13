using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace HuTao.NET.Auth
{
    public class BrowserLogin : IDisposable
    {
        private IWebDriver driver;

        public BrowserLogin()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            driver = new ChromeDriver();
        }

        public BrowserLogin(IDriverConfig driverConfig, IWebDriver webDriver)
        {
            new DriverManager().SetUpDriver(driverConfig, VersionResolveStrategy.MatchingBrowser);
            driver = webDriver;
        }

        public void OpenBrowser()
        {
            driver.Navigate().GoToUrl("https://www.hoyolab.com/home");
        }

        public Cookie GetCookie()
        {
            string ltuid = driver.Manage().Cookies.GetCookieNamed("ltuid").Value;
            string ltoken = driver.Manage().Cookies.GetCookieNamed("ltoken").Value;
            return new Cookie() { ltoken = ltoken, ltuid = ltuid };
        }

        public void CloseBrowser()
        {
            driver.Quit();
            driver.Close();
        }

        public void Dispose()
        {
            CloseBrowser();
        }
    }
}