using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using E2ESeleniumDemo.Commons;
using E2ESeleniumDemo.Utilities;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Runtime.CompilerServices;

namespace E2ESeleniumDemo.Base
{
    public class BaseTest
    {
       // public ExtentReports report;
       
       public static ThreadLocal<IWebDriver> tlDriver = new ThreadLocal<IWebDriver>();

        //[OneTimeSetUp]
        //protected void setResources()
        //{
        //    report = ExtentManager.initializeReporting();
        //}

       protected static IWebDriver driver;
                  
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

        //[MethodImpl(MethodImplOptions.Synchronized)]
        //public static ExtentReports getReport()
        //{
        //    return tlReport.Value;
        //}

        [TearDown]
        protected void cleanUp()
        {
            getDriver().Quit();
           

        }
       
       
       
       
        
    }
}
