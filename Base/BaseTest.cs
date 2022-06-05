using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;

using System.Threading;
using System.Runtime.CompilerServices;
using E2ESeleniumDemo.Utility;
using E2ESeleniumDemo.TestClasses;

namespace E2ESeleniumDemo.Base
{
    public class BaseTest
    {
       public ExtentReports report;
       
       public static ThreadLocal<IWebDriver> tlDriver = new ThreadLocal<IWebDriver>();
       public static ThreadLocal<ExtentTest> tlTest = new ThreadLocal<ExtentTest>();

        [SetUp]
        public void InitReport()
        {
            tlTest.Value = ExtentSetup.report.CreateTest(TestContext.CurrentContext.Test.ClassName);
        }
        protected IWebDriver Initialize(string browserType)
        { 
            
            if (browserType.ToLower() == "chrome")
            { 
              tlDriver.Value = new ChromeDriver();

            }else if (browserType.ToLower() == "edge")
            {
                 tlDriver.Value = new EdgeDriver();
            }
            getDriver().Manage().Window.Maximize();
            getDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
            return getDriver();
        }
        
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IWebDriver getDriver()
        {
            return tlDriver.Value;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest getTest()
        {
            return tlTest.Value;
        }

        [TearDown]
        protected void AfterTest()
        {
            var Status = TestContext.CurrentContext.Result.Outcome.Status;

            switch (Status)
            {
                case TestStatus.Passed:
                    getTest().Log(AventStack.ExtentReports.Status.Pass, "TestCase Passed");
                    break;
                case TestStatus.Failed:
                    getTest().Log(AventStack.ExtentReports.Status.Fail, "TestCase Failed");
                    getTest().AddScreenCaptureFromBase64String(ScreenshotUtility.TakeScreenshot(getDriver()));
                     break;
                default:
                    getTest().Log(AventStack.ExtentReports.Status.Info, "Something went wrong!");
                    break;

            }
            getDriver().Quit();    

        }
         
        
    }
}
