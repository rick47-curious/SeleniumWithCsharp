using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using E2ESeleniumDemo.Base;

using System.Threading;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;

namespace E2ESeleniumDemo.TestClasses
{
    [TestFixture,Order(2)]
    class ParallelTesting :BaseTest
    {

        

        [SetUp]
        public void Init()
        {           
            
            //With chrome browser
            Initialize("chrome").Url =  "https://jsbin.com/osebed/2";

            GetTest().Log(Status.Info, "Test Execution started");

        }
        [Parallelizable(ParallelScope.Self)]
        [Test,Category("Parallel Test"),Category("ModuleTesting"),]
        public void TestMultipleDropDown()
        {   
          
            IWebElement elementList = GetDriver().FindElement(By.Id("fruits"));

            SelectElement selectElement = new SelectElement(elementList);

            if (selectElement.IsMultiple)
            {
                selectElement.SelectByIndex(0);
                selectElement.SelectByIndex(1);
                selectElement.SelectByIndex(2);
            }
            GetTest().Log(Status.Pass, "Multiple value selected");
            Thread.Sleep(2000);
           
        }
        
        [Parallelizable(ParallelScope.Self)]
        [Test, Category("Parallel Test"), Category("ModuleTesting")]
        public void TestMultipleDropDown2()
        {
           

            IWebElement elementList = GetDriver().FindElement(By.Id("fruits"));

            SelectElement selectElement = new SelectElement(elementList);

            if (selectElement.IsMultiple)
            {
                selectElement.SelectByIndex(0);
                selectElement.SelectByIndex(1);
                selectElement.SelectByIndex(2);
            }
            GetTest().Log(Status.Pass, "Multiple Value selected");
            Thread.Sleep(2000);
            
        }
    }
    
}
