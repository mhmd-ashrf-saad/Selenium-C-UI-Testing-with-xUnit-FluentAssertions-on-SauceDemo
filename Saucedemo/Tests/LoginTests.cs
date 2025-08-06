using FluentAssertions;
using Saucedemo.Drivers;
using Saucedemo.Pages;

namespace Saucedemo.Tests
{
    public class LoginTests : IClassFixture<WebDriverFixture>
    {
        private readonly WebDriverFixture fixture;

        public LoginTests(WebDriverFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void Successful_Login_Should_Navigate_To_Inventory_Page()
        {
            var loginPage = new LoginPage(fixture.Driver);
            loginPage.Login("standard_user", "secret_sauce");

            //Assert
            fixture.Driver.Url.Should().Contain("/inventory.html");

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
