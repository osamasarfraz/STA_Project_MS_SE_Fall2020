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
        #region All Elements ID's Initilizing form webpage

        int milliseconds = (2000);
        By goToLoginBtn = By.CssSelector("a[href='http://automationpractice.com/index.php?controller=my-account']");

        By email = By.Id("email");
        By password = By.Id("passwd");
        By submitBtn = By.Id("SubmitLogin");
        By selectCategoryBtn = By.ClassName("sf-with-ul");
        By selectProductBtn = By.ClassName("icon-th-list");
        By addToCartBtn = By.XPath("//div[@class='button-container col-xs-7 col-md-12']//a[@class='button ajax_add_to_cart_button btn btn-default']");
        By goToCartBtn = By.XPath("//div[@class='button-container']//a[@class='btn btn-default button button-medium']");
        By cartQuantityUpBtn = By.Id("cart_quantity_up_1_1_0_420195");
        By proceedToCheckOutBtn = By.XPath("//span[text()='Proceed to checkout']");
        #endregion

        public void CheckOutMethod(string url, string userEmail, string userPassword)
        {
            OpenUrl(url);
            ImplicitWait(milliseconds);
            Action_Click(goToLoginBtn);
            WriteLine(email, userEmail);
            WriteLine(password, userPassword);
            Action_Click(submitBtn);
            ImplicitWait(milliseconds);
            Action_Click(selectCategoryBtn);
            ImplicitWait(milliseconds);
            ScrollTo(820);
            Action_Click(selectProductBtn);
            ImplicitWait(milliseconds);
            Action_Click(addToCartBtn);
            ImplicitWait(60);
            Action_Click(goToCartBtn);
            ScrollTo(500);
            ImplicitWait(180);
            Action_Click(cartQuantityUpBtn);
            Action_Click(proceedToCheckOutBtn);
            ImplicitWait(milliseconds);
            Action_Click(proceedToCheckOutBtn);
            ImplicitWait(milliseconds);
            ScrollTo(200);
        }
    }
}
