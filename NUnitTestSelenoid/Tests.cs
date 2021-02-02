using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitTestSelenoid
{
    public class Tests
    {
        private IWebDriver Driver;
        
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Driver = new ChromeDriver(@"D:\Projects\Experiments\Drivers");
            Driver.Url = "http://www.google.com";
        }
        
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        [TestCase("Selenoid")]
        public void Test1(string expectedResult)
        {
           
            IWebElement searchInput = Driver.FindElement(By.XPath("//input[@type='text']"));          
            searchInput.SendKeys(expectedResult);
            searchInput.SendKeys(Keys.Enter);
            IWebElement firstResult = Driver.FindElement(By.XPath("//div[@class='g']//span[text()[contains(.,'Selenoid')]]"));
            string firstResaltString = firstResult.Text;
            Assert.IsTrue(firstResaltString.Contains(expectedResult),
                $"Expected: {expectedResult}. Actual: {firstResaltString}");
            Assert.Pass();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Driver.Quit();
        }
    }
}