using CynkyWrapper;
using OpenQA.Selenium;

namespace LumaShoppingAutomation.PageObjects.CommonPages
{
    public class MyAccountPage
    {
        IWebDriver _Driver;

        public MyAccountPage(IWebDriver driver)
        {
            _Driver = driver;
        }

        #region Locators

        PageElement ContactInformation_label => new PageElement(_Driver, By.XPath($"//div[contains(@class,'box-information')]//p"));

        #endregion

        #region Actions

        public string GetContactInformation()
        {
            return ContactInformation_label.GetText();
        }

        #endregion
    }
}