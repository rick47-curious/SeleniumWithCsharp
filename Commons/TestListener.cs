using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using E2ESeleniumDemo.Base;
using AventStack.ExtentReports;
using System.Runtime.CompilerServices;
using E2ESeleniumDemo.Utilities;

namespace E2ESeleniumDemo.Commons
{
    
    public class TestListener :  ITestListener
    {
        ExtentReports report;
        public static ThreadLocal<ExtentTest> tlTest = new ThreadLocal<ExtentTest>(); 
        public void SendMessage(TestMessage message)
        {
           //Nothing
        }
        
        public void TestFinished(ITestResult result)
        {
            report.Flush();
        }
        
        public void TestOutput(TestOutput output)
        {
            tlTest.Value.Log(Status.Info, "Test" + output.TestName + "ran completely");
        }

        [OneTimeSetUp]
        protected void setResources()
        {
            report = ExtentManager.initializeReporting();
        }
        
        public void TestStarted(ITest test)
        {
            tlTest.Value = report.CreateTest(test.ClassName).CreateNode(test.ClassName);
        }

        
    }
}
