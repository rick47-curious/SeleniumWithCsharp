using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace E2ESeleniumDemo.Utilities
{
    
    class ExtentManager
    {
        static ExtentReports report;
        
        
        public static ExtentReports initializeReporting()
        {
            report = new ExtentReports();
            var reporter = new ExtentHtmlReporter(@"D:\DotnetWorkspace\E2ESeleniumDemo\Reports\Report.html");
            report.AttachReporter(reporter);
            
            return report;
        }

    }
}
