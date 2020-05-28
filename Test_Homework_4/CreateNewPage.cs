using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Test_Homework_4
{
    class CreateNewPage
    {
        private IWebDriver driver;

        public CreateNewPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        // Метод заполняет поля нового продукта на странице Create New и нажимает кнопку "Отправить"
        public CreateNewPage CreateCakePops(string ProductName,string CategoryId, string SupplierId, string UnitPrice, 
                                 string QuantityPerUnit, string UnitsInStock, string UnitsOnOrder, string ReorderLevel)
        {
            driver.FindElement(By.Id("ProductName")).SendKeys(ProductName);

            var selectElement = new SelectElement(driver.FindElement(By.Id("CategoryId")));
            selectElement.SelectByText(CategoryId);
            selectElement = new SelectElement(driver.FindElement(By.Id("SupplierId")));
            selectElement.SelectByText(SupplierId);
            driver.FindElement(By.Id("UnitPrice")).SendKeys(UnitPrice);
            driver.FindElement(By.Id("QuantityPerUnit")).SendKeys(QuantityPerUnit);
            driver.FindElement(By.Id("UnitsInStock")).SendKeys(UnitsInStock);
            driver.FindElement(By.Id("UnitsOnOrder")).SendKeys(UnitsOnOrder);
            driver.FindElement(By.Id("ReorderLevel")).SendKeys(ReorderLevel);
            driver.FindElement(By.CssSelector(".btn")).Click();
            return new CreateNewPage(driver);
        }
    }
}
