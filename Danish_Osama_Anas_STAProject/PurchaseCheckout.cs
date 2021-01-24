using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace Danish_Osama_Anas_STAProject
{
    class PurchaseCheckout : BaseClass
    {
        #region Path Of ScreenShots
        string path_loginPage = "./LoginScreen.png";
        string path_loginSuccess = "./LoginSuccess.png";
        string path_categoryScreen = "./category.png";
        string path_cartPopUp = "./popUpCart.png";
        string path_checkOut = "./checkOut.png";
        string path_checkOutSuccess = "./checkOutSuccess.png";
        string path_paymentSuccess = "./paymentSuccess.png";
        #endregion
        #region All Elements ID's Initilizing form webpage

        int delay = (2000);
        By goToLoginBtn = By.CssSelector("a[href='http://automationpractice.com/index.php?controller=my-account']");

        By email = By.Id("email");
        By password = By.Id("passwd");
        By submitBtn = By.Id("SubmitLogin");
        By selectCategoryBtn = By.ClassName("sf-with-ul");
        By selectProductBtn = By.ClassName("icon-th-list");
        By addToCartBtn = By.XPath("//div[@class='button-container col-xs-7 col-md-12']//a[@class='button ajax_add_to_cart_button btn btn-default']");
        By goToCartBtn = By.CssSelector("#layer_cart > div.clearfix > div.layer_cart_cart.col-xs-12.col-md-6 > div.button-container > a");
        By cartQuantityUpBtn = By.Id("cart_quantity_up_1_1_0_420195");
        By proceedToCheckOutBtn = By.XPath("//span[text()='Proceed to checkout']");
        By shippingCheckOutBtn = By.CssSelector("#form > p > button > span");
        By agreeCheckBox = By.Id("cgv");
        By payByBankBtn = By.CssSelector("#HOOK_PAYMENT > div:nth-child(1) > div > p > a");
        By confirmOrder = By.CssSelector("#cart_navigation > button");
        By successMessage = By.CssSelector("#center_column > div > p > strong");
        #endregion

        public void CheckOutMethod(string url, string userEmail, string userPassword, string purchasedMsg)
        {
            OpenUrl(url);
            ImplicitWait(delay);
            MoveToBtnAndClick(goToLoginBtn);
            WriteLine(email, userEmail);
            WriteLine(password, userPassword);
            MoveToBtnAndClick(submitBtn);
            Test_ScreenShot(path_loginPage);
            ImplicitWait(delay);
            Test_ScreenShot(path_loginSuccess);
            MoveToBtnAndClick(selectCategoryBtn);
            Test_ScreenShot(path_categoryScreen);
            ImplicitWait(delay);
            ScrollTo(820);
            MoveToBtnAndClick(selectProductBtn);
            ImplicitWait(delay);
            MoveToBtnAndClick(addToCartBtn);
            Test_ScreenShot(path_cartPopUp);
            Thread.Sleep(delay);
            ImplicitWait(180);
            MoveToBtnAndClick(goToCartBtn);
            Test_ScreenShot(path_checkOut);
            ImplicitWait(180);
            ScrollTo(500);
            ImplicitWait(180);
            MoveToBtnAndClick(cartQuantityUpBtn);
            MoveToBtnAndClick(proceedToCheckOutBtn);
            ImplicitWait(delay);
            MoveToBtnAndClick(proceedToCheckOutBtn);
            Test_ScreenShot(path_checkOutSuccess);
            ImplicitWait(delay);
            MoveToBtnAndClick(agreeCheckBox);
            ScrollTo(500);
            Thread.Sleep(delay);
            MoveToBtnAndClick(shippingCheckOutBtn);
            ImplicitWait(delay);
            MoveToBtnAndClick(payByBankBtn);
            ImplicitWait(delay);
            MoveToBtnAndClick(confirmOrder);
            Test_ScreenShot(path_paymentSuccess);
            
            ImplicitWait(delay);
            Assert.AreEqual(purchasedMsg, driver.FindElement(successMessage).Text);
            Thread.Sleep(delay);
        }
    }
}
