using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Test_Homework_4
{
    class AllProductsPage
    {
        private IWebDriver driver;

        public AllProductsPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement nameAllProductsPage => driver.FindElement(By.XPath("//h2[contains(.,'All Products')]"));
        public string GetNameAllProductsPage()  //Метод  возвращает название страницы All Products.
        {
            return nameAllProductsPage.Text;
        }
        private IWebElement clickButtonCreateNew => driver.FindElement(By.LinkText("Create new"));
        public CreateNewPage createNewPage()    //Метод  нажимает "Create new" на странице All Products.
        { 
        new Actions(driver).Click(clickButtonCreateNew).Build().Perform();
        return new CreateNewPage(driver);
        }
    }
}
