using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Test_Homework_4
{
    class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        
        private IWebElement loginField => driver.FindElement(By.Id("Name"));
        private IWebElement passwordField => driver.FindElement(By.Id("Password"));
        //Метод вводит логин и пароль на странице Login.
        public HomePage ResultLoginPage (string username, string passwd)
        {
            new Actions(driver).Click(loginField).SendKeys(username).Build().Perform();
            new Actions(driver).SendKeys(Keys.Enter).Build().Perform();
            new Actions(driver).Click(passwordField).SendKeys(passwd).Build().Perform();
            new Actions(driver).SendKeys(Keys.Enter).Build().Perform();
            return new HomePage(driver);
        }

    }
}
