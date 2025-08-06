using OpenQA.Selenium;

namespace Saucedemo.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver) => _driver = driver;

        private IWebElement UsernameInput => _driver.FindElement(By.Id("user-name"));
        private IWebElement PasswordInput => _driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => _driver.FindElement(By.Id("login-button"));

        public void Login(string username, string password)
        {
            UsernameInput.SendKeys(username);
            PasswordInput.SendKeys(password);
            LoginButton.Click();
        }
    }
}
