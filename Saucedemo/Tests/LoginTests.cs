using FluentAssertions;
using Saucedemo.Drivers;
using Saucedemo.Pages;

namespace Saucedemo.Tests
{
    public class LoginTests : IClassFixture<WebDriverFixture>, IDisposable
    {
        private readonly WebDriverFixture fixture;

        public LoginTests(WebDriverFixture fixture)
        {
            this.fixture = fixture;
        }

        public void Dispose()
        {
            fixture.Driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [Theory]
        [InlineData("standard_user", "secret_sauce")]
        [InlineData("locked_out_user", "secret_sauce")]
        [InlineData("problem_user", "secret_sauce")]
        [InlineData("performance_glitch_user", "secret_sauce")]
        [InlineData("error_user", "secret_sauce")]
        [InlineData("visual_user", "secret_sauce")]
        public void Successful_Login_Should_Navigate_To_Inventory_Page(string username, string password)
        {
            var loginPage = new LoginPage(fixture.Driver);
            loginPage.Login(username, password);

            //Assert
            fixture.Driver.Url.Should().Contain("/inventory");

        }

        [Fact]

        public void Invalid_Login_Should_Display_Error_Message()
        {
            //Arrange
            var loginPage = new LoginPage(fixture.Driver);

            //Act
            loginPage.Login("invalid_user", "wrong_password");
            var errorMessage = loginPage.GetErrorMessage();

            //Assert
            errorMessage.Should().Contain("Username and password do not match")
                .And.NotBeNullOrEmpty();

        }
    }
}
