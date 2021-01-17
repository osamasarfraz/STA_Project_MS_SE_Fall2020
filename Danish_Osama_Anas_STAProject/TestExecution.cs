using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace Danish_Osama_Anas_STAProject
{
    [TestClass]
    public class TestExecution
    {
        #region Initilization & CleanUp
        public TestContext instance;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }

        [TestInitialize()]

        public void TestInit()
        {
            BaseClass.SeleniumInit();
        }

        [TestCleanup()]
        public void TestCleanUp()
        {
            BaseClass.CloseSelenium();
        }

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {

        }

        [ClassCleanup()]
        public static void ClassCleanUp()
        {

        }
        #endregion
        [TestMethod]
        [TestCategory("Positive Case & Negative Case")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"DataforDataDrivenTest.xml", "Login", DataAccessMethod.Sequential)]
        public void ModeledTestCase()
        {
            #region Variable Declarations
            string url = this.TestContext.DataRow["url"].ToString();
            string userEmail = this.TestContext.DataRow["userName"].ToString();
            string userPassword = this.TestContext.DataRow["userPassword"].ToString();
            #endregion

            PurchaseCheckout purchaseCheckout = new PurchaseCheckout();

            purchaseCheckout.CheckOutMethod(url, userEmail, userPassword);
        }
    }
}
