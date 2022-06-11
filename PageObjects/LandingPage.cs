using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;


namespace E2ESeleniumDemo.PageObjects
{
    class LandingPage
    {
        private IWebDriver Driver;
        public LandingPage(IWebDriver Driver)
        {
            this.Driver = Driver;
        }
        //Locators
       private string XpathpageLink = "(//a[@class='cart-header-navlink'])[2]";


        public SearchPage HitSearchPage()
        {

            Driver.FindElement(By.XPath(XpathpageLink)).Click();

            IList<string> windows = Driver.WindowHandles;
            
            Driver.SwitchTo().Window(windows[1]);
            
            return new SearchPage(Driver);
        }
    }
}
