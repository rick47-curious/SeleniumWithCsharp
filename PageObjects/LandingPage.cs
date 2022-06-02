using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;


namespace E2ESeleniumDemo.PageObjects
{
    class LandingPage
    {
        private IWebDriver driver;
        public LandingPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        //Locators
       private string XpathpageLink = "(//a[@class='cart-header-navlink'])[2]";


        public SearchPage HitSearchPage()
        {

            driver.FindElement(By.XPath(XpathpageLink)).Click();

            IList<string> windows = driver.WindowHandles;
            
            driver.SwitchTo().Window(windows[1]);
            
            return new SearchPage(driver);
        }
    }
}
