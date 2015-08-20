using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WngCalculator.AutoTest
{
    class Program
    {
        static string appRunMode;
        static IWebDriver driver;
        static void Main(string[] args)
        {
            Console.WriteLine("Auto Test is starting ...");
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();

            string appUrl = GetUrl();
            MinTest(driver, appUrl);
            NegativeNumberInputTest(appUrl);
            FloatNumberInputTest(appUrl);
            MaxTest(appUrl);

            driver.Quit();
        }

        private static void MaxTest(string appUrl)
        {
            driver.Navigate().GoToUrl(appUrl);
            driver.FindElement(By.Id("InputData_Number")).SendKeys("9");
            driver.FindElement(By.CssSelector("input[type=submit]")).Click();
            string allNumbers = driver.FindElement(By.CssSelector("#AllNumbers p")).Text;
            Assert.AreEqual("1,2,3,4,5,6,7,8,9,", allNumbers);
            string oddNumbers = driver.FindElement(By.CssSelector("#OddNumbers p")).Text;
            Assert.AreEqual("1,2,3,4,5,6,7,8,9,", oddNumbers);
            string evenNumbers = driver.FindElement(By.CssSelector("#EvenNumbers p")).Text;
            Assert.AreEqual("1,2,3,4,5,6,7,8,9,", evenNumbers);
            string cezNumbers = driver.FindElement(By.CssSelector("#CezNumbers p")).Text;
            Assert.AreEqual("1,2,3,4,5,6,7,8,9,", cezNumbers);
            string fibonacci = driver.FindElement(By.CssSelector("#Fibonacci p")).Text;
            Assert.AreEqual("1,2,3,4,5,6,7,8,9,", fibonacci);
        }

        private static void FloatNumberInputTest(string appUrl)
        {
            driver.Navigate().GoToUrl(appUrl);
            driver.FindElement(By.Id("InputData_Number")).SendKeys("5.5");
            driver.FindElement(By.CssSelector("input[type=submit]")).Click();
            bool jqueryBelivesIsVisible = IsValidationMessageVisible("The value must be a positive integer.");
            Assert.AreEqual(true, jqueryBelivesIsVisible);
        }

        private static void NegativeNumberInputTest(string appUrl)
        {
            driver.Navigate().GoToUrl(appUrl);
            driver.FindElement(By.Id("InputData_Number")).SendKeys("-3");
            driver.FindElement(By.CssSelector("input[type=submit]")).Click();
            bool jqueryBelivesIsVisible = IsValidationMessageVisible("The value must be a positive integer.");
            Assert.AreEqual(true, jqueryBelivesIsVisible);
        }

        private static void MinTest(IWebDriver driver, string appUrl)
        {
            driver.Navigate().GoToUrl(appUrl);
            driver.FindElement(By.CssSelector("input[type=submit]")).Click();
            bool jqueryBelivesIsVisible = IsValidationMessageVisible("The Number field is required.");
            Assert.AreEqual(true, jqueryBelivesIsVisible);
            
        }

        private static bool IsValidationMessageVisible(string validationMessage)
        {
            var js = driver as IJavaScriptExecutor;
            if (js == null)
                throw new Exception("IJavaScriptExecutor not avaliable");

            return (bool)js.ExecuteScript("return $('span:contains(\"" + validationMessage + "\")').is(\":visible\");");
        }

        private static string GetUrl()
        {
            string appUrl = null;
            //string appRunMode = null;

            if (ConfigurationManager.AppSettings["AppRunMode"] == null)
                throw new ApplicationException("Cannot find ConfigurationManager.AppSettings[\"AppRunModel\"]");

            appRunMode = ConfigurationManager.AppSettings["AppRunMode"].ToString();

            if (appRunMode.ToLower() == "prod")
            {
                if (ConfigurationManager.AppSettings["ProdLoginUrl"] == null)
                    throw new ApplicationException("Cannot find ConfigurationManager.AppSettings[\"ProdLoginUrl\"]");

                appUrl = ConfigurationManager.AppSettings["ProdLoginUrl"].ToString();
            }
            else if (appRunMode == "dev")
            {
                if (ConfigurationManager.AppSettings["DevLoginUrl"] == null)
                    throw new ApplicationException("Cannot find ConfigurationManager.AppSettings[\"LocLoginUrl\"]");

                appUrl = ConfigurationManager.AppSettings["DevLoginUrl"].ToString();
            }
            else
            {
                throw new ArgumentOutOfRangeException("AppRunMode");
            }
            return appUrl;
        }
    }
}
