using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using System.Threading;

namespace CSharpPractice
{
    internal class UtilityPrograms
    {
        static IWebDriver driver;
        public static void loadBrowser()
        {

            // Automatically downloads the correct version of ChromeDriver
            new DriverManager().SetUpDriver(new ChromeConfig());

            // Launch browser
            driver = new ChromeDriver();

            // Navigate to a website
            //driver.Navigate().GoToUrl("https://www.google.com");

            // Optional: Close the browser after use
            // driver.Quit();
        }


        public static void getDataFromTablePresentInWebPage()
        {

            /*              Sample HTML Code for Table
                           
                        < table id = "customers" >
                          < thead >
                            < tr >
                              < th > Coapny </ th >
                              < th > Contact </ th >
                              < th > Country </ th >
                            </ tr >
                          </ thead >
                          < tbody >
                            < tr >
                              < td > Alfreds Futterkiste </ td >
                              < td > Maria Anders </ td >
                              < td > Germany </ td >
                            </ tr >
                          </ tbody >
                        </ table >


            ==================================

            < table >
                < thead >
                    < tr >
                        < th >
                        < th >
                    </ tr >
                < thead >
                          </ tbody >
                        </ table >
             */
            loadBrowser();
            driver.Navigate().GoToUrl("https://www.w3schools.com/html/html_tables.asp");
            
            //Locate the table
            IWebElement table = driver.FindElement(By.Id("customers"));

            //get all rows under tbody
            IList<IWebElement> rows = table.FindElements(By.XPath(".//tbody/tr"));
            

            foreach (IWebElement row in rows)
            {
                //Get all headers (th) in first row
                IList<IWebElement> header = row.FindElements(By.TagName("th"));
                foreach (IWebElement col in header)
                {
                    Console.Write(col.Text + "\t\t" + "|");

                }

                Console.WriteLine();

                //Get all columns (td) in this row
                IList<IWebElement> cols = row.FindElements(By.TagName("td"));

                foreach (IWebElement col in cols)
                {
                    Console.Write(col.Text + "\t\t" + "|");

                }
                Console.WriteLine();
            }


        }

    }
}
