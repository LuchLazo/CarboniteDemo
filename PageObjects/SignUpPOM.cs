using OpenQA.Selenium;

namespace CarboniteDemo.PageObjects
{
    class SignUpPOM
    {
        private IWebDriver driver;

        public SignUpPOM(IWebDriver driver)
        {
            // test
            this.driver = driver;
        }

        public IWebElement GetBannerCircle()
        {
            var banner = driver.FindElement(By.XPath("//div[@id='cookieBanner']"));
            return banner.FindElement(By.XPath("//button[@class='circle']"));
        }

        public IWebElement GetEmailGroup()
        {
            return driver.FindElement(By.XPath("//div[@field='Email']"));
        }


        public IWebElement GetConfirmEmailGroup()
        {
            return driver.FindElement(By.XPath("//div[@field='ConfirmEmail']"));
        }

        public IWebElement GetPasswordGroup()
        {
            return driver.FindElement(By.XPath("//div[@field='Password']"));
        }

        public IWebElement GetConfirmPasswordGroup()
        {
            return driver.FindElement(By.XPath("//div[@field='ConfirmPassword']"));
        }


        public IWebElement GetInputInGroup(IWebElement formGroup)
        {
            return formGroup.FindElement(By.XPath(".//input"));
        }


        public IWebElement GetErrorInGroup(IWebElement formGroup)
        {
            return formGroup.FindElement(By.XPath(".//span[@class='help-block']"));
        }
    }
}
