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
        private CreateNewPage createNewProduct; //��� ������������� ������ �������� ������ ��������.
        private const string login = "user";
        private const string password = "user";

        [OneTimeSetUp]      //�������� �������� ����� ����������� ���� ������.
        public void BeforeTestSuit()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http:\\localhost:5000");
            driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]       //�������� �������� ����� ���������� ���� ������.
        public void AfterTestSuit()
        {
            driver.Close();
            driver.Quit();
        }

        [Test]
        public void Test1_Login()   //���� �� �����.
        {
            loginPage = new LoginPage(driver);
            homePage = loginPage.ResultLoginPage(login,password);
            // �������� �� �������� �������� Home page ����� ������.
            Assert.AreEqual("Home page", homePage.GetNameHomePage());   // ������� �������� Home page.
        }

        [Test]
        public void Test2_CreateProduct()   // ��������� ������ ��������.
        {
            allProductsPage = homePage.HomePageToAllProductsPage(); // ��������� �������� All Products
            createNewPage = allProductsPage.createNewPage();    // ��������� �������� Create New
            createNewProduct =  createNewPage.CreateCakePops("Cake pops", "Confections", "Specialty Biscuits, Ltd.",
                               "15", "2 boxes x 7 pieces", "20", "0", "10");    // ������� ����� �������.
            // �������� �� �������� �������� All Products ����� ������� ������ "���������" �������� Create New.
            Assert.AreEqual("All Products", allProductsPage.GetNameAllProductsPage());
            // �������� ������� �������� Cake pops �� �������� All Products
            Assert.AreEqual("Cake pops", allProductsPage.GetNameNewProduct());
        }

        [Test]
        public void Test5_Logout()      // �������� �� ������.
        {
            loginPage = allProductsPage.AllProductsPageToLogin();
            // �������� �� �������� �������� Login  ����� ������� ������ Logout
            Assert.AreEqual("Login", loginPage.GetNameLoginPage());
        }
    }
}