using System;
using System.Collections.ObjectModel;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V85.Debugger;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace RestService
{
    [TestClass]
    public class UnitTestAnother
    {
        private static readonly string DriverDirectory = "C:\\webDrivers"; //important correct directory for driver
        private static IWebDriver _driver; //Remember nuget packages Selenium Webdriver and --|-- .ChromeDriver

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new ChromeDriver(DriverDirectory);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void TestMethod1()
        {
            string url = "http://127.0.0.1:5500/index.html";
            _driver.Navigate().GoToUrl(url);

            string title = _driver.Title;
            Assert.AreEqual("Web app", title);

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(1000)); // decorator pattern?
            IWebElement itemsTable = wait.Until(d => d.FindElement(By.Id("itemsTable")));
            Assert.IsTrue(itemsTable.Text.Contains("Chocolate"));

            // We already did the waiting in the previous lines, so now we can go back to using the ordinary driver
            ReadOnlyCollection<IWebElement> listElements = _driver.FindElements(By.TagName("tr"));
            //Each row is counted, including header rows and input field rows
            Assert.AreEqual(8, listElements.Count);
            int originalCount = listElements.Count;

            Assert.IsTrue(listElements[1].Text.Contains("Chocolate"));

            _driver.FindElement(By.Id("id")).Clear();
            _driver.FindElement(By.Id("id")).SendKeys("2");
            _driver.FindElement(By.Id("name")).SendKeys("Coffee mug");
            _driver.FindElement(By.Id("price")).Clear();
            _driver.FindElement(By.Id("price")).SendKeys("75");
            _driver.FindElement(By.Id("description")).Clear();
            _driver.FindElement(By.Id("description")).SendKeys("Super delicious mug");

            _driver.FindElement(By.Id("addButton")).Click();

            Thread.Sleep(5000); // Waits for an updated table
            listElements = _driver.FindElements(By.TagName("tr"));
            Assert.AreEqual(originalCount + 1, listElements.Count);

            // XPath, an advanced option to use By.XPath(...)
            // https://www.guru99.com/handling-dynamic-selenium-webdriver.html
        }
    }
}
