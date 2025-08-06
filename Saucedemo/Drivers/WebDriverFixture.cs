using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Saucedemo.Drivers
{
    public class WebDriverFixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        public WebDriverFixture()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
