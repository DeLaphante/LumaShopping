using CynkyWrapper;
using LumaShoppingAutomation.Models.UI;
using OpenQA.Selenium;
using System;
using System.Linq;

namespace LumaShoppingAutomation.PageObjects.CommonPages
{
    public class ItemsPage : Navigation
    {
        IWebDriver _Driver;

        public ItemsPage(IWebDriver driver) : base(driver)
        {
            _Driver = driver;
        }

        #region Locators

        PageElement Items_label(string itemColor) => new PageElement(_Driver, By.XPath($"//div[contains(@class,'product details')]//div[contains(@option-label,'{itemColor}')]"));
        PageElement ItemSize_button(string itemColor, string itemSize, int index) => new PageElement(_Driver, By.XPath($"(//div[contains(@class,'product details') and .//div[contains(@option-label,'{itemColor}')]]//div[text()='{itemSize}'])[{index}]"));
        PageElement ItemColor_button(string itemColor, int index) => new PageElement(_Driver, By.XPath($"(//div[contains(@class,'product details')]//div[contains(@option-label,'{itemColor}')])[{index}]"));
        PageElement AddToCart_button(string itemColor, int index) => new PageElement(_Driver, By.XPath($"(//div[contains(@class,'product details') and .//div[contains(@option-label,'{itemColor}')]]//button[@title='Add to Cart'])[{index}]"));
        PageElement CartItemsNumber_label => new PageElement(_Driver, By.XPath($"//span[@class='counter-label']"));

        #endregion

        #region Actions

        public void AddItemToCart(Customer customer)
        {
            foreach (var item in customer.ItemsColor)
            {
                if (!Items_label(item).IsDisplayed())
                    throw new Exception("Dropdown arrow not displayed!");

                for (int counter = 1; counter <= Items_label(item).GetAllElements().Count; counter++)
                {
                    ItemSize_button(item, customer.ItemsSize, counter).Click();
                    ItemColor_button(item, counter).Click();
                    AddToCart_button(item, counter).Click();
                   if (!CartItemsNumber_label.IsDisplayed())
                        throw new Exception("Cart not being displayed!");
                }
            }
        }

        public string GetNumberOfItemsInCart()
        {
            return CartItemsNumber_label.GetText();
        }

        public int GetTotalNumberOfItems(Customer customer)
        {
            int total = 0;
            foreach (var item in customer.ItemsColor)
            {
                total = total + Items_label(item).GetAllElements().Count;
            }
            return total;
        }

        #endregion
    }
}