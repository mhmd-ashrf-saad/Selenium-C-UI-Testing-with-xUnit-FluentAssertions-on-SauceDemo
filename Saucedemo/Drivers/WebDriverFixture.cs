using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Saucedemo.Drivers
{
    public class WebDriverFixture : IDisposable

    {
        public IWebDriver Driver { get; private set; }

        public WebDriverFixture()
        {
            var options = new ChromeOptions();
            var prefs = new Dictionary<string, object>
        {
            { "credentials_enable_service", false },
            { "profile.password_manager_enabled", false }
        };
            options.AddArgument("--incognito");
            options.AddArgument("--disable-features=PasswordManagerEnableMigration");
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);



            Driver = new ChromeDriver(options);

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
