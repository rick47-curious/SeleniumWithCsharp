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
        private IWebDriver Driver;
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

        public SearchPage(IWebDriver Driver)
        {
            this.Driver = Driver;
        }
        public void SetTripType(Dictionary<string,string> data)
        {
            IList<IWebElement> tripRadio = Driver.FindElements(By.XPath(XpathTripType));
            if (data["Trip"] =="One Way")
            {
                tripRadio[0].Click();
            }else if (data["Trip"] == "Round Trip")
            {
                tripRadio[1].Click();
            }
        }
        public void EnterFormDetails(Dictionary<string,string> data)
        {
            Driver.FindElement(By.Id(IDDropDown)).Click();

            Properties.SetVisibiltyExplicitWait(Driver, XpathFromTable, Properties.PropertyType.Xpath);

            //Setting From Location
            Properties.SetLocation(Driver,XpathFromLocation, data,"FromLocation");

            //Setting To Location
            Properties.SetLocation(Driver, XpathToLocation, data,"ToLocation");
        }

        public void EnterDateDetails(Dictionary<string,string> data)
        {
            //Set Departure date
            Properties.SetDate(Driver, data, XpathDate,"DepartDate");

            //Set Return date (if any)
            if (data["ReturnDate"] != string.Empty)
            {
                Properties.SetDate(Driver, data, XpathDate,"ReturnDate");
            }
        }
        
        public void SelectPassengers(Dictionary<string,string> data)
        {
            Driver.FindElement(By.XPath("//*[@class='row1 adult-infant-child']/div[@id='divpaxinfo']")).Click();
            //Taking that only adult is considered as a passenger
            if (data["Passenger"] == "1")
            {

            }else if (data["Passenger"] == "2")
            {
                Driver.FindElement(By.XPath(XpathIncrementButton)).Click();
            }

            Driver.FindElement(By.XPath(XpathDoneButton)).Click();

        }

        public void SelectCurrency(Dictionary<string,string> data)
        {
            SelectElement element = new SelectElement(Driver.FindElement(By.Id(SelectID)));

            element.SelectByText(data["Currency"]);

            Driver.FindElement(By.Id(searchButtonID)).Click();
        }
        
    }
}
