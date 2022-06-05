using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using E2ESeleniumDemo.Utilities;
using NUnit.Framework;

namespace E2ESeleniumDemo.TestClasses
{
    [SetUpFixture]
    class ExtentSetup
    {
       
        public static ExtentReports report;
        
        [OneTimeSetUp]
        protected void InitializeReporting()
        {
            report = new ExtentReports();
            var reporter = new ExtentHtmlReporter(@"D:\DotnetWorkspace\E2ESeleniumDemo\Reports\Report.html");
            report.AttachReporter(reporter);
        }

        [OneTimeTearDown]
        protected void FlushReport()
        {
            report.Flush();
        }
    }
}
