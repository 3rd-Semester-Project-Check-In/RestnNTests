using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestOgTestsTests1.UITests
{
    [TestClass]
    public class SeleniumTests
    {
        private static readonly string DriverDirectory = "C:\\webDrivers";

        private static IWebDriver _driver;
        //private string driverUrl;

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
        public void TestWithSelenium()
        {
            string url = "file:///C:/Users/caspe/Desktop/VueApp-master/Index.html";

            _driver.Navigate().GoToUrl(url);

            Thread.Sleep(3000);

            IWebElement adminControls = _driver.FindElement(By.Id("admin-controls"));
            adminControls.Click();

            Thread.Sleep(4000);

            IWebElement quote = _driver.FindElement(By.Id("quoteb"));
            quote.Click();

            Thread.Sleep(4000);

            IWebElement postlokaleId = _driver.FindElement(By.Id("lokaleId-input"));
            postlokaleId.SendKeys("B2.07");

            Thread.Sleep(3000);

            IWebElement postcardId = _driver.FindElement(By.Id("cardId-input"));
            postcardId.SendKeys("2");

            Thread.Sleep(3000);

            IWebElement postbtn = _driver.FindElement(By.Id("postbtn"));
            postbtn.Click();

            Thread.Sleep(3000);

            IWebElement getlokale = _driver.FindElement(By.Id("getById-input"));
            getlokale.SendKeys("B2.07");

            Thread.Sleep(3000);

            IWebElement getbtn = _driver.FindElement(By.Id("getbtn"));
            getbtn.Click();

            Thread.Sleep(3000);

            IWebElement deletelokale = _driver.FindElement(By.Id("delete-input"));
            deletelokale.SendKeys("B2.07");

            Thread.Sleep(3000);

            IWebElement delbtn = _driver.FindElement(By.Id("deletebtn"));
            delbtn.Click();

            Thread.Sleep(3000);

            _driver.Quit();
        }
    }
}
