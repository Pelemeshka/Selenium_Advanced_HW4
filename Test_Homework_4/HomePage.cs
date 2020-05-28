using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Test_Homework_4
{
    class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement nameHomePage => driver.FindElement(By.XPath("//h2[contains(.,'Home page')]"));
        public string GetNameHomePage() //Метод  возвращает название страницы Home.
        {
            return nameHomePage.Text;
        }
        private IWebElement MenuAllProductsPage => driver.FindElement(By.LinkText("All Products"));

        public AllProductsPage HomePageToAllProductsPage() // Метод нажимает пункт меню All Products.
        {
        new Actions(driver).Click(MenuAllProductsPage).Build().Perform();
        return new AllProductsPage(driver);
        }
    }
}
