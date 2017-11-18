using Cibertec.Automation;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Cibertec.AutomationTest
{
    public class LoginPageTestNavigation
    {
        public LoginPageTestNavigation()
        {
            Driver.GetInstance(DriversOption.Chrome);
        }

        [Fact]
        public void LoginTest()
        {
            LoginPage.Go();
            LoginPage.LoginAs("alexrod2121@gmail.com").WithPassword("password").Login();

            Thread.Sleep(TimeSpan.FromSeconds(2));
            LoginPage.GetUrl().Should().Be("http://localhost/angular/#!/home");
            LoginPage.Logout();
            Driver.CloseInstance();
        }

        [Fact]
        public void LoginWrongTest()
        {
            LoginPage.Go();
            LoginPage.LoginAs("alexrod2121@gmail.com").WithPassword("44879878").Login();

            Thread.Sleep(TimeSpan.FromSeconds(2));
            LoginPage.IsAlertErrorPresent().Should().BeTrue();
            Driver.CloseInstance();
        }
    }
}
