using CynkyWrapper;
using CynkyWrapper.Configuration;
using DemoAutomation.Models.UI;
using OpenQA.Selenium;
using System;

namespace DemoAutomation.PageObjects.CommonPages
{
    public class Navigation
    {
        IWebDriver _Driver;

        public Navigation(IWebDriver driver)
        {
            _Driver = driver;
        }

        #region Locators

        PageElement Button(string text, int index) => new PageElement(_Driver, By.XPath($"(//button[contains(.,'{text}')])[{index}]"));
        protected PageElement Header_label => new PageElement(_Driver, By.TagName("h1"));
        PageElement MyCart_link => new PageElement(_Driver, By.XPath("//a[contains(.,'My Cart')]"));
        PageElement TopBar_link(string option) => new PageElement(_Driver, By.XPath($"(//a[normalize-space(text()) = '{option}'])[1]"));
        PageElement NavBarMenu_link(string option) => new PageElement(_Driver, By.XPath($"//nav[@class='navigation']//li[contains(.,'{option}')]"));
        PageElement NavBarMenuArrow_label => new PageElement(_Driver, By.XPath($"(//span[contains(@class,'ui-menu-icon')])[1]"));
        PageElement SubMenuOption_link(string option, string subOption) => new PageElement(_Driver, By.XPath($"//nav[@class='navigation']//li[contains(.,'{option}')]//li[contains(.,'{subOption}')]"));
        PageElement CheckoutSuccess_label => new PageElement(_Driver, By.ClassName("checkout-success"));

        #endregion

        #region Actions

        public void NavigateToHomePage()
        {
            _Driver.Navigate().GoToUrl(CynkyConfigManager.SiteUrl);
        }

        public string GetPageHeader()
        {
            return Header_label.GetText();
        }

        public string GetCheckOutSuccessMessage()
        {
            return CheckoutSuccess_label.GetText();
        }

        public void ClickButton(string text, int index = 1)
        {
            Button(text, index).Click();
        }

        public void NavigateToMenuOption(string option, Customer customer = null)
        {
            switch (option.ToLower())
            {
                case "tops":
                    NavBarMenuArrow_label.IsDisplayed();
                    NavBarMenu_link(customer.ShoppingGender).MoveToElement();
                    SubMenuOption_link(customer.ShoppingGender, "Tops").Click();
                    break;
                case "sign in":
                case "create an account":
                    TopBar_link(option).Click();
                    break;
                case "my cart":
                    MyCart_link.Click();
                    break;
                default:
                    throw new Exception("Unknown Menu Option!");
            }
        }

        #endregion
    }
}