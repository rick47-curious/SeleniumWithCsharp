using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace E2ESeleniumDemo.Utility
{
    class ScreenshotUtility
    {
        
        public static String TakeScreenshot(IWebDriver driver)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;

            Screenshot screenshot = takesScreenshot.GetScreenshot();

            return screenshot.AsBase64EncodedString;
        }
    }
}
