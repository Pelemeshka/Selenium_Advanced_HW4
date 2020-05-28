using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Test_Homework_4
{
    public class Tests
    {
        public IWebDriver driver;
        private LoginPage loginPage;
        private HomePage homePage;
        private AllProductsPage allProductsPage;
        private CreateNewPage createNewPage;
        private CreateNewPage createNewProduct; //Для инициализации метода создания нового продукта.
        private const string login = "user";
        private const string password = "user";

        [OneTimeSetUp]      //Открытие страницы перед выполнением всех тестов.
        public void BeforeTestSuit()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http:\\localhost:5000");
            driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]       //Закрытие страницы после выполнения всех тестов.
        public void AfterTestSuit()
        {
            driver.Close();
            driver.Quit();
        }

        [Test]
        public void Test1_Login()   //Тест на Логин.
        {
            loginPage = new LoginPage(driver);
            homePage = loginPage.ResultLoginPage(login,password);
            // Проверка на открытие страницы Home page после Логина.
            Assert.AreEqual("Home page", homePage.GetNameHomePage());   // Открыта страница Home page.
        }

        [Test]
        public void Test2_CreateProduct()   // Созданиие нового продукта.
        {
            allProductsPage = homePage.HomePageToAllProductsPage(); // Открываем страницу All Products
            createNewPage = allProductsPage.createNewPage();    // Открываем страницу Create New
            createNewProduct =  createNewPage.CreateCakePops("Cake pops", "Confections", "Specialty Biscuits, Ltd.",
                               "15", "2 boxes x 7 pieces", "20", "0", "10");    // Создаем новый продукт.
            // Проверка на открытие страницы All Products после нажатия кнопки "Отправить" страницы Create New.
            Assert.AreEqual("All Products", allProductsPage.GetNameAllProductsPage());
            // Проверка наличия продукта Cake pops на странице All Products
            Assert.AreEqual("Cake pops", allProductsPage.GetNameNewProduct());
        }

        [Test]
        public void Test5_Logout()      // Проверка на Логаут.
        {
            loginPage = allProductsPage.AllProductsPageToLogin();
            // Проверка на открытие страницы Login  после нажатия кнопки Logout
            Assert.AreEqual("Login", loginPage.GetNameLoginPage());
        }
    }
}