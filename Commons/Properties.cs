using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace E2ESeleniumDemo.Commons
{
    public class Properties
    {
        public static IWebDriver driver { get; set; }

        public enum PropertyType
        {
            Id,
            Name,
            Class,
            Xpath,
            Css
        }
        public static void setVisibiltyExplicitWait(IWebDriver driver, String locator, PropertyType type)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            if (type == PropertyType.Id)
            {

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(locator)));
            }
            else if (type == PropertyType.Xpath)
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(locator)));
            }
        }

        public static void setLocation(IWebDriver driver, string XpathLocator, Dictionary<string, string> data, string locationType)
        {
            IList<IWebElement> locationColumn = driver.FindElements(By.XPath(XpathLocator));

            for (int i = 0; i < locationColumn.Count; i++)
            {

                IList<IWebElement> rows = locationColumn[i].FindElements(By.XPath("li"));


                foreach (IWebElement row in rows)
                {
                    string rowName = row.FindElement(By.XPath("a")).Text;
                    if (rowName.Contains(data[locationType]))
                    {
                        row.Click();
                    }
                }
            }
        }

        public static void setDate(IWebDriver driver, Dictionary<string, string> data, string Xpath,string dateType)
        {
            IWebElement calenderTable = driver.FindElement(By.XPath(Xpath));

            string inputDate = data[dateType].Split("-")[0];
            string inputMonth = data[dateType].Split("-")[1];
            bool flag = false;

            while (true)
            {
                string calenderMonth = calenderTable.FindElement(By.XPath("div[contains(@class,'group-first')]/div/div/span[1]")).Text;

                if (inputMonth == calenderMonth)
                {
                    flag = true;
                }
                else
                {
                    calenderTable.FindElement(By.XPath("div[2]/div/a")).Click();
                }
                if (flag)
                    break;
            }

            if (flag == true)
            {
                flag = false;
                IList<IWebElement> calenderRows = calenderTable.FindElements(By.XPath("div[contains(@class,'group-first')]/table/tbody/tr"));

                for (int i = 0; i < calenderRows.Count; i++)
                {
                    calenderRows = calenderTable.FindElements(By.XPath("div[contains(@class,'group-first')]/table/tbody/tr"));
                    //Getting number of date element in a row
                    IList<IWebElement> calenderDate = calenderRows[i].FindElements(By.XPath("td"));
                    for (int j = 0; j < calenderDate.Count; j++)
                    {
                        calenderDate = calenderRows[i].FindElements(By.XPath("td"));
                        try
                        {
                            string date = calenderDate[j].FindElement(By.XPath("a")).Text;

                            if (inputDate == date)
                            {
                                calenderDate[j].FindElement(By.XPath("a")).Click();
                                flag = true;
                                break;
                            }
                        }
                        catch (Exception NullException)
                        {
                            //If the date is blank for some dates in a week
                            continue;
                        }

                    }
                    if (flag)
                        break;
                }


            }

        }

    }
}
