using CynkyDriver;
using CynkyDriver.Configuration;
using LumaShoppingAutomation.Models.UI;
using OpenQA.Selenium;
using System;

namespace LumaShoppingAutomation.PageObjects.CommonPages
{
    public class Navigation
    {
        protected IWebDriver _Driver;

        public Navigation(IWebDriver driver)
        {
            _Driver = driver;
        }

        #region Locators

        PageElement Button(string text, int index = 1) => new PageElement(_Driver, By.XPath($"(//*[translate(normalize-space(.),'ABCDEFGHIJKLMNOPQRSTUVWXYZ','abcdefghijklmnopqrstuvwxyz')= \"{text.ToLower()}\"]//ancestor::*[(self::button or self::a or @onclick or @role='button') and contains(translate(normalize-space(.),'ABCDEFGHIJKLMNOPQRSTUVWXYZ','abcdefghijklmnopqrstuvwxyz'),\"{text.ToLower()}\")and not(contains(@class,'disable') or @disabled)][last()])[{index}]"));
        protected PageElement Header_label => new PageElement(_Driver, By.TagName("h1"));
        PageElement MyCart_link => new PageElement(_Driver, By.XPath("//a[contains(.,'My Cart')]"));
        PageElement TopBar_link(string option) => new PageElement(_Driver, By.XPath($"(//a[normalize-space(text()) = '{option}'])[1]"));
        PageElement NavBarMenu_link(string option) => new PageElement(_Driver, By.XPath($"//nav[@class='navigation']//li[contains(.,'{option}')]"));
        PageElement SubMenuOption_link(string option, string subOption) => new PageElement(_Driver, By.XPath($"//nav[@class='navigation']//li[contains(.,'{option}')]//li[contains(.,'{subOption}')]"));
        PageElement CheckoutSuccess_label => new PageElement(_Driver, By.ClassName("checkout-success"));

        #endregion

        #region Actions

        public void NavigateToHomePage()
        {
            _Driver.Navigate().GoToUrl(CynkyConfigManager.BaseSiteUrl);
            AcceptCookie();
        }
        public void AcceptCookie()
        {
            if (Button("DISAGREE").IsDisplayed())
                Button("DISAGREE").Click();
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