using CynkyDriver;
using LumaShoppingAutomation.Models.UI;
using OpenQA.Selenium;

namespace LumaShoppingAutomation.PageObjects.CommonPages
{
    public class CreateNewCustomerAccountPage
    {
        IWebDriver _Driver;

        public CreateNewCustomerAccountPage(IWebDriver driver)
        {
            _Driver = driver;
        }

        #region Locators

        PageElement Inputfields_textbox(string idName) => new PageElement(_Driver, By.Id($"{idName}"));
        PageElement Submit_button => new PageElement(_Driver, By.XPath($"//button[@title='Create an Account']"));

        #endregion

        #region Actions

        public void CreateAccount(Customer customer)
        {
            Inputfields_textbox("firstname").SendKeys(customer.FirstName);
            Inputfields_textbox("lastname").SendKeys(customer.LastName);
            Inputfields_textbox("email_address").SendKeys(customer.Email);
            Inputfields_textbox("password").SendKeys(customer.Password);
            Inputfields_textbox("password-confirmation").SendKeys(customer.Password);
            Submit_button.Click();
        }

        #endregion
    }
}