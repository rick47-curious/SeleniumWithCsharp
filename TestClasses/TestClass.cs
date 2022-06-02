using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using E2ESeleniumDemo.Base;
using E2ESeleniumDemo.Commons;

namespace E2ESeleniumDemo
{
    [TestFixture]
    class TestClass :BaseTest
    {
        
        [SetUp]
        public void init()
        {
            //With chrome browser
            Initialize("chrome").Url = "https://jsbin.com/osebed/2";
            

        }
       
        [Test,Order(1),Category("SmokeTest")]
        public void TestSingleSelection()
        {
            IWebElement elementList = getDriver().FindElement(By.Id("fruits"));

            SelectElement selectElement = new SelectElement(elementList);

            selectElement.SelectByText("Apple");

            
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
            Thread.Sleep(2000);
        }
    }
}
