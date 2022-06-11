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
    [TestFixture,Order(1)]
    class ValidateBooking:BaseTest
    {

        LandingPage LandingPage;
        SearchPage SearchPage;
        

        
        [SetUp]
        public void Init()
        {
            Initialize("chrome").Url = "https://rahulshettyacademy.com/seleniumPractise/#/";

            GetTest().Log(Status.Info, "Test Execution started");
        }
        [Test,Order(1)]
        public void DirectToSearchPage()
        {
            try
            {
               
                LandingPage = new LandingPage(GetDriver());
                LandingPage.HitSearchPage();

            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            GetTest().Log(Status.Pass, "Redirection successfull");
            Thread.Sleep(3000);
            
        }
        [Test,Order(2)]
        [TestCaseSource(typeof(Utilities.ExcelReaderUtil), nameof(Utilities.ExcelReaderUtil.GetTestData))]
        public void SearchFlights(Dictionary<string, string> data)
        {
            try
            {
               
                LandingPage = new LandingPage(GetDriver());
                SearchPage = LandingPage.HitSearchPage();

                SearchPage.SetTripType(data);
                SearchPage.EnterFormDetails(data);
                SearchPage.EnterDateDetails(data);
                SearchPage.SelectPassengers(data);
                SearchPage.SelectCurrency(data);
               
            }catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            
            GetTest().Log(Status.Pass, "Values entered successfully");
            Thread.Sleep(2000);
        }
    }
}
