using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using E2ESeleniumDemo.Base;
using E2ESeleniumDemo.Commons;
using AventStack.ExtentReports;
using E2ESeleniumDemo.TestClasses;

namespace E2ESeleniumDemo.TestClasses
{
    [TestFixture,Order(0)]
    class TestClass :BaseTest
    {
      
        [SetUp]
        public void init()
        {
            
            //With chrome browser
            Initialize("chrome").Url = "https://jsbin.com/osebed/2";

            getTest().Log(Status.Info, "Test Execution started");

        }
       
        [Test,Order(1),Category("SmokeTest")]
        public void TestSingleSelection()
        {
            IWebElement elementList = getDriver().FindElement(By.Id("fruits"));

            SelectElement selectElement = new SelectElement(elementList);

            selectElement.SelectByText("Apple");

            getTest().Log(Status.Pass, "Apple selected");
            Thread.Sleep(2000);
        }
        [Test,Order(2),Category("RegressionTest")]
        public void TestMultipleSelection()
        {
            IWebElement elementList = getDriver().FindElement(By.Id("fruits"));

            SelectElement selectElement = new SelectElement(elementList);

            if (selectElement.IsMultiple)
            {
                selectElement.SelectByIndex(0);
                selectElement.SelectByIndex(1);
                selectElement.SelectByIndex(2);
            }
            getTest().Log(Status.Pass, "Multiple Value selected");
            Thread.Sleep(2000);
        }
    }
}
