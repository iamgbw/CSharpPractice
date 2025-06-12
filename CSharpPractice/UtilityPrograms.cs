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


        public static void useGetHandlesMethod()
        {
            List<string> windowHandles = new List<string>(driver.WindowHandles);

            Console.WriteLine("Window Handles:");
            foreach (var handle in windowHandles)
            {
                Console.WriteLine(handle);
            }

            // Switch to the second tab (Google)
            driver.SwitchTo().Window(windowHandles[1]);
            Console.WriteLine("Switched to: " + driver.Title);

            // Switch back to the first tab
            driver.SwitchTo().Window(windowHandles[0]);
            Console.WriteLine("Switched back to: " + driver.Title);

            // Close all windows
            driver.Quit();


        }


        public static async Task findBrokenLinks()
        {
            // Step 1: Launch Chrome browser using Selenium WebDriver
            loadBrowser();

            // Step 2: Navigate to the website
            driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");

            // Step 3: Find all <a> (anchor) tags on the page - these represent links
            IList<IWebElement> links = driver.FindElements(By.TagName("a"));
            Console.WriteLine($"Total Links found = {links.Count}");

            // Step 4: Create a HttpClient to make HTTP requests to each link
            using (HttpClient client = new HttpClient())
            {
                // Step 5: Loop through each link element
                foreach (IWebElement link in links)
                {
                    // Get the value of the href attribute (the actual URL)
                    // Returns a null if the value is not set.
                    string url = link.GetAttribute("href");

                    // Check that the URL is not null/empty and is an HTTP or HTTPS link
                    if (!string.IsNullOrEmpty(url) && (url.StartsWith("http") || url.StartsWith("https")))
                    {
                        try
                        {
                            // Step 6: Send a GET request to the URL
                            HttpResponseMessage response = await client.GetAsync(url);

                            // Step 7: Convert the HTTP status code from enum to integer
                            // e.g., 200 = OK, 404 = Not Found
                            // Convert the HTTP status (e.g. OK, NotFound) from enum to number (e.g. 200, 404)
                            int statusCode = (int)response.StatusCode;

                            // Step 8: Check if the link is broken (status code 400 or above)
                            if(statusCode >= 400)
                                Console.WriteLine($"❌ Broken Link: {url} (Status Code: {statusCode})");
                            else
                                Console.WriteLine($"✅ Working Link: {url} (Status Code: {statusCode})");

                        }

                        catch (Exception ex)
                        {
                            // Step 9: If an exception occurs (e.g., timeout, DNS error), mark link as broken
                            Console.WriteLine($"❗ Error accessing {url} - Marked as Broken");
                        }
                    }
                }

                // Step 10: Close the browser after checking all links
                driver.Quit();
                Console.WriteLine("✅ Done checking links.");
            }


        }

    }
}
