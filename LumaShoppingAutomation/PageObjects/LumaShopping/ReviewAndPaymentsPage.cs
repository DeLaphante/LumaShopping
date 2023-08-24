using CynkyWrapper;
using OpenQA.Selenium;

namespace DemoAutomation.PageObjects.CommonPages
{
    public class ReviewAndPaymentsPage : Navigation
    {
        IWebDriver _Driver;

        public ReviewAndPaymentsPage(IWebDriver driver) : base(driver)
        {
            _Driver = driver;
        }

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