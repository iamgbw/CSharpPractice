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
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

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


        public static void captureScreenshot()
        {
            loadBrowser();
            driver.Navigate().GoToUrl("https://www.w3schools.com/html/html_tables.asp");
            driver.Navigate().Refresh();    // Refresh the browser

            ITakesScreenshot screenshotDriver = (ITakesScreenshot)driver;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile(@"C:\Users\ganesh.waghmare\OneDrive - Nihilent Limited\Desktop\screenshot.png");

        }

        public static void readDataFromExcel()
        {
            // Provide the full path to your Excel file
            string filePath = @"C:\Users\ganesh.waghmare\OneDrive - Nihilent Limited\Desktop\Data.xlsx";

            // Open the Excel file
            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read ))
            {
                // Load the workbook
                XSSFWorkbook workbook = new XSSFWorkbook(file);

                // Get the first worksheet
                ISheet sheet = workbook.GetSheetAt(0);

                // Loop through all rows in the sheet
                for (int rowIndex = 0; rowIndex <= sheet.LastRowNum; rowIndex++)
                {
                    IRow row = sheet.GetRow(rowIndex);

                    if (row != null)
                    {
                        // Loop through all cells in the row
                        for (int colIndex = 0; colIndex < row.LastCellNum; colIndex++)
                        {
                            ICell cell = row.GetCell(colIndex);

                            // Print the cell value (if null, print "NULL")
                            Console.Write((cell != null ? cell.ToString() : "NULL") + "\t");
                        }
                        Console.WriteLine(); // Move to next line after each row
                    }
                }
            }

        }

        public static void downloadFileAndVerifySomeFieldsInDownloadedFile()
        {
            // Step 1: Set download directory
            string downloadPath = @"C:\DownloadedFiles";

            // Create the directory if it doesn't exist
            if (!Directory.Exists(downloadPath))
            {
                Directory.CreateDirectory(downloadPath);
            }

            // Step 2: Set Chrome options to define download behavior
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("download.default_directory", downloadPath);
            chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");

            // Step 3: Launch Chrome browser with these options
            driver = new ChromeDriver(chromeOptions);


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
