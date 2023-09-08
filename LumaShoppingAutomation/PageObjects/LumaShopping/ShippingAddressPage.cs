using CynkyWrapper;
using LumaShoppingAutomation.Models.UI;
using OpenQA.Selenium;

namespace LumaShoppingAutomation.PageObjects.CommonPages
{
    public class ShippingAddressPage : Navigation
    {
        IWebDriver _Driver;

        public ShippingAddressPage(IWebDriver driver) : base(driver)
        {
            _Driver = driver;
        }

        #region Locators

        PageElement Inputfields_textbox(string name) => new PageElement(_Driver, By.Name($"{name}"));
        PageElement Email_textbox => new PageElement(_Driver, By.XPath($"(//input[@id='customer-email'])[1]"));

        #endregion

        #region Actions

        public void EnterShippingAddress(Customer customer)
        {
            Inputfields_textbox("country_id").SelectByText(customer.Country);
            Email_textbox.SendKeys(customer.Email);
            Inputfields_textbox("firstname").SendKeys(customer.FirstName);
            Inputfields_textbox("lastname").SendKeys(customer.LastName);
            Inputfields_textbox("street[0]").SendKeys(customer.StreetAddress);
            Inputfields_textbox("city").SendKeys(customer.City);
            Inputfields_textbox("telephone").SendKeys(customer.PhoneNumber);
            ClickButton("Next");
        }

        #endregion
    }
}