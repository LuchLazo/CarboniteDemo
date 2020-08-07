
using System;

using OpenQA.Selenium;

using OpenQA.Selenium.Chrome;
using CarboniteDemo.PageObjects;

using NUnit.Framework;

namespace CarboniteDemo
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;
        public string homeURL;

        [SetUp]
        public void SetUp()
        {
            Console.WriteLine("Setup running...");
            homeURL = "https://www.carbonite.com/backup-software/safe-personal-trial/";
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }


        [Test(Description = "TC037: Checks if email validator catches invalid emails")]
        public void CheckSigninEmail()  
        {
            driver.Navigate().GoToUrl(homeURL);

            var POM = new SignUpPOM(driver);
            
            var EmailFormGroup = POM.GetEmailGroup();
            var EmailInput = POM.GetInputInGroup(EmailFormGroup);

            EmailInput.SendKeys("luch@luch.c");

            var error = POM.GetErrorInGroup(EmailFormGroup);
            var errorText = error.Text;

            Assert.AreEqual("Must be valid email", errorText);
        }

        [Test(Description = "TC039: Checks if email validator catches mismatched emails")]
        public void CheckEmailsMatch()
        {
            driver.Navigate().GoToUrl(homeURL);

            var POM = new SignUpPOM(driver);

            var EmailFormGroup = POM.GetEmailGroup();
            var ConfirmEmailFormGroup = POM.GetConfirmEmailGroup();

            var EmailInput = POM.GetInputInGroup(EmailFormGroup);
            var ConfirmEmailInput = POM.GetInputInGroup(ConfirmEmailFormGroup);

            EmailInput.SendKeys("luch@luch.com");
            ConfirmEmailInput.SendKeys("luch@luch.net");

            var error = POM.GetErrorInGroup(ConfirmEmailFormGroup);
            var errorText = error.Text;

            Assert.AreEqual("Email must match confirm email", errorText);
        }


        [Test(Description = "TC040:Checks if password validator detects passwords too short")]
        public void CheckPasswordLength()
        {
            driver.Navigate().GoToUrl(homeURL);

            var POM = new SignUpPOM(driver);

            var PasswordFormGroup = POM.GetPasswordGroup();
            var PasswordInput = POM.GetInputInGroup(PasswordFormGroup);

            PasswordInput.SendKeys("abc");

            var error = POM.GetErrorInGroup(PasswordFormGroup);
            var errorText = error.Text;

            Assert.AreEqual("The password field must be at least 8 characters.", errorText);
        }


        [Test(Description = "TC043: Checks if password validator detects mismatching passwords")]
        public void CheckPasswordsMatch()
        {
            driver.Navigate().GoToUrl(homeURL);

            var POM = new SignUpPOM(driver);

            var PasswordFormGroup = POM.GetPasswordGroup();
            var ConfirmPassowordFormGroup = POM.GetConfirmPasswordGroup();

            var PasswordInput = POM.GetInputInGroup(PasswordFormGroup);
            var ConfirmPasswordInput = POM.GetInputInGroup(ConfirmPassowordFormGroup);

            PasswordInput.SendKeys("Password123");
            ConfirmPasswordInput.SendKeys("Password125");

            var error = POM.GetErrorInGroup(ConfirmPassowordFormGroup);
            var errorText = error.Text;

            Assert.AreEqual("The confirm password confirmation does not match.", errorText);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}