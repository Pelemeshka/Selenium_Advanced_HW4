using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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

        private IWebElement productNameField => driver.FindElement(By.Id("ProductName"));
        private IWebElement categoryIDField => driver.FindElement(By.Id("CategoryId"));
        private IWebElement supplierIDField => driver.FindElement(By.Id("SupplierId"));
        private IWebElement unitPriceField => driver.FindElement(By.Id("UnitPrice"));
        private IWebElement quantityPerUnitField => driver.FindElement(By.Id("QuantityPerUnit"));
        private IWebElement unitsInStockField => driver.FindElement(By.Id("UnitsInStock"));
        private IWebElement unitsOnOrderField => driver.FindElement(By.Id("UnitsOnOrder"));
        private IWebElement reorderLevelField => driver.FindElement(By.Id("ReorderLevel"));
        private IWebElement sendCreateNewButton => driver.FindElement(By.CssSelector(".btn"));

        // Метод заполняет поля нового продукта на странице Create New и нажимает кнопку "Отправить"
        public CreateNewPage CreateCakePops(string ProductName,string CategoryId, string SupplierId, string UnitPrice, 
                                 string QuantityPerUnit, string UnitsInStock, string UnitsOnOrder, string ReorderLevel)
        {
            new Actions(driver).Click(productNameField).SendKeys(ProductName).Build().Perform();
            var selectElement = new SelectElement(categoryIDField);
            selectElement.SelectByText(CategoryId);
            selectElement = new SelectElement(supplierIDField);
            selectElement.SelectByText(SupplierId);
            new Actions(driver).Click(unitPriceField).SendKeys(UnitPrice).Build().Perform();
            new Actions(driver).Click(quantityPerUnitField).SendKeys(QuantityPerUnit).Build().Perform();
            new Actions(driver).Click(unitsInStockField).SendKeys(UnitsInStock).Build().Perform();
            new Actions(driver).Click(unitsOnOrderField).SendKeys(UnitsOnOrder).Build().Perform();
            new Actions(driver).Click(reorderLevelField).SendKeys(ReorderLevel).Build().Perform();
            new Actions(driver).Click(sendCreateNewButton).Build().Perform();
            return new CreateNewPage(driver);
        }
    }
}
