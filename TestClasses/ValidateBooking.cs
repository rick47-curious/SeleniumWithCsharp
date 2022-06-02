using AventStack.ExtentReports;
using NUnit.Framework;
using E2ESeleniumDemo.Base;
using E2ESeleniumDemo.Commons;
using E2ESeleniumDemo.PageObjects;
using E2ESeleniumDemo.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace E2ESeleniumDemo.TestClasses
{
    [TestFixture]
    class ValidateBooking: BaseTest
    {

        LandingPage LandingPage;
        SearchPage SearchPage;
        ExtentTest test;

        [SetUp]
        public void init()
        {
            Initialize("chrome").Url = "https://rahulshettyacademy.com/seleniumPractise/#/";
        }
        [Test,Order(1)]
        public void directToSearchPage()
        {
            try
            {
               
                LandingPage = new LandingPage(getDriver());
                LandingPage.HitSearchPage();
                //Adding the logs
                

            }catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            Thread.Sleep(3000);
            
        }
        [Test,Order(2)]
        [TestCaseSource(typeof(Utilities.ExcelReaderUtil), nameof(Utilities.ExcelReaderUtil.getTestData))]
        public void searchFlights(Dictionary<string, string> data)
        {
            try
            {
               
                LandingPage = new LandingPage(getDriver());
                SearchPage = LandingPage.HitSearchPage();

                SearchPage.setTripType(data);
                SearchPage.enterFormDetails(data);
                SearchPage.enterDateDetails(data);
                SearchPage.selectPassengers(data);
                SearchPage.selectCurrency(data);
               
            }catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            Thread.Sleep(2000);
        }
    }
}
