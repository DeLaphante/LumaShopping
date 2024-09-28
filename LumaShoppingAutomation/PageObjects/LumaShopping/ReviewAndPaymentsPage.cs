using CynkyDriver;
using OpenQA.Selenium;

namespace LumaShoppingAutomation.PageObjects.CommonPages
{
    public class ReviewAndPaymentsPage : Navigation
    {
        public ReviewAndPaymentsPage(IWebDriver driver) : base(driver) { }

        #region Locators

        PageElement BillingAddress_label => new PageElement(_Driver, By.ClassName("billing-address-details"));
        PageElement ShipToAddress_label => new PageElement(_Driver, By.ClassName("shipping-information-content"));

        #endregion

        #region Actions

        public string GetBillingAddress()
        {
            return BillingAddress_label.GetText();
        }

        public string GetShipToAddress()
        {
            return ShipToAddress_label.GetText();
        }

        #endregion
    }
}