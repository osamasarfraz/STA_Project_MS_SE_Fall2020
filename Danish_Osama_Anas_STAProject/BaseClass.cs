using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Configuration;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace Danish_Osama_Anas_STAProject
{
    [TestClass]
    public class BaseClass
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static IWebDriver driver;
        public static IJavaScriptExecutor js;
        public static IWebDriver SeleniumInit()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            log.Info("Driver Initialized, Chrome Open & Maximize");

            js = (IJavaScriptExecutor)driver;
            return driver;
        }

        public static void CloseSelenium()
        {
            driver.Close();
            driver.Quit();
            driver.Dispose();
            log.Info("Chrome & Web Driver Closed");
        }

        public void WriteLine(By by, string text)
        {
            try
            {
                driver.FindElement(by).SendKeys(text);
                log.Info("Text Input Successfull");
            }
            catch (Exception ex)
            {
                log.Error(ex + "Unable to input text");
            }
        }

        public void Click(By by)
        {
            try
            {
                driver.FindElement(by).Click();
                log.Info("Button Clicked Successfully");
            }
            catch (Exception ex)
            {
                log.Error(ex + "Button Clicked Failed");
            }
        }

        public void Action_Click(By by)
        {
            try
            {
                IWebElement action_click = driver.FindElement(by);
                Actions action = new Actions(driver);
                action.MoveToElement(action_click).Click().Perform();
                log.Info("Clicked By Actions Lib Successfull");
            }
            catch (Exception ex)
            {
                log.Error(ex + "Clicked By Actions Lib Successfull");
            }
        }

        public void Replace_Word(string Replace)
        {
            string replace_string = Replace;
            replace_string = replace_string.Replace(" ", "");
            string rep_str = replace_string.ToUpper();
            Thread.Sleep(2000);
        }

        public void OpenUrl(string url)
        {
            try
            {
                driver.Url = url;
                log.Info("Desired Url Open Successfully");
            }
            catch (Exception ex)
            {
                log.Error(ex + "Desired Url Open Failed");
            }
        }

        public void Field_Clear(By by)
        {
            try
            {
                driver.FindElement(by).Clear();
                log.Info("Clear Method Passed");
            }
            catch (Exception ex)
            {
                log.Error(ex + "Clear Method Failed");
            }
        }

        public void ImplicitWait(float milliseconds)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(milliseconds);
        }

        public void ScrollTo(int value)
        {
            js.ExecuteScript("window.scrollTo(0, " + value + ")");
        }

        public void Test_ScreenShot(string path)
        {
            Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
            string ScreenShotName = path;
            image.SaveAsFile(ScreenShotName, ScreenshotImageFormat.Png);
        }

        public void Page_scrolldown(By by)
        {
            IWebElement s = driver.FindElement(by);
            IJavaScriptExecutor je = (IJavaScriptExecutor)driver;
            je.ExecuteScript("arguments[0].scrollIntoView(true);", s);
        }
    }
}
