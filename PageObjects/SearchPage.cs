using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using E2ESeleniumDemo.Commons;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace E2ESeleniumDemo.PageObjects
{
    class SearchPage
    {
        private IWebDriver driver;
        //Locators
        private string IDDropDown = "ctl00_mainContent_ddl_originStation1_CTXT";
        private string XpathFromTable = "//*[@id='citydropdown']";
        private string XpathFromLocation = "//*[@id='citydropdown']//div[@id='dropdownGroup1']/div/ul";
        private string XpathToLocation = "(//*[@id='citydropdown'])[2]//div[@id='dropdownGroup1']/div/ul";
        private string XpathTripType = "//*[@id='ctl00_mainContent_rbtnl_Trip']//td";
        private string XpathDate = "//*[@id='ui-datepicker-div' and contains(@style,'position')]";
        private string XpathIncrementButton = "(//*[@class='row1 adult-infant-child']/div[@id='divpaxOptions']//div[@class='ad-row-right'])[1]/span[3]";
        private string XpathDoneButton = "//*[@id='btnclosepaxoption']";
        private string SelectID = "ctl00_mainContent_DropDownListCurrency";
        private string searchButtonID = "ctl00_mainContent_btn_FindFlights";

        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void setTripType(Dictionary<string,string> data)
        {
            IList<IWebElement> tripRadio = driver.FindElements(By.XPath(XpathTripType));
            if (data["Trip"] =="One Way")
            {
                tripRadio[0].Click();
            }else if (data["Trip"] == "Round Trip")
            {
                tripRadio[1].Click();
            }
        }
        public void enterFormDetails(Dictionary<string,string> data)
        {
            driver.FindElement(By.Id(IDDropDown)).Click();

            Properties.setVisibiltyExplicitWait(driver, XpathFromTable, Properties.PropertyType.Xpath);

            //Setting From Location
            Properties.setLocation(driver,XpathFromLocation, data,"FromLocation");

            //Setting To Location
            Properties.setLocation(driver, XpathToLocation, data,"ToLocation");
        }

        public void enterDateDetails(Dictionary<string,string> data)
        {
            //Set Departure date
            Properties.setDate(driver, data, XpathDate,"DepartDate");

            //Set Return date (if any)
            if (data["ReturnDate"] != string.Empty)
            {
                Properties.setDate(driver, data, XpathDate,"ReturnDate");
            }
        }
        
        public void selectPassengers(Dictionary<string,string> data)
        {
            driver.FindElement(By.XPath("//*[@class='row1 adult-infant-child']/div[@id='divpaxinfo']")).Click();
            //Taking that only adult is considered as a passenger
            if (data["Passenger"] == "1")
            {

            }else if (data["Passenger"] == "2")
            {
                driver.FindElement(By.XPath(XpathIncrementButton)).Click();
            }

            driver.FindElement(By.XPath(XpathDoneButton)).Click();

        }

        public void selectCurrency(Dictionary<string,string> data)
        {
            SelectElement element = new SelectElement(driver.FindElement(By.Id(SelectID)));

            element.SelectByText(data["Currency"]);

            driver.FindElement(By.Id(searchButtonID)).Click();
        }
        
    }
}
