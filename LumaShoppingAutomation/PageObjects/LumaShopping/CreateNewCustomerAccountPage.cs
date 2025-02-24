using CynkyDriver;
using LumaShoppingAutomation.Models.UI;
using OpenQA.Selenium;

namespace LumaShoppingAutomation.PageObjects.CommonPages
{
    public class CreateNewCustomerAccountPage : Navigation
    {
        public CreateNewCustomerAccountPage(IWebDriver driver) : base(driver)
        {
            _Driver = driver;
        }

        #region Locators

        PageElement Inputfields_textbox(string idName) => new PageElement(_Driver, By.Id($"{idName}"));

        #endregion

        #region Actions

        public void CreateAccount(Customer customer)
        {
            Inputfields_textbox("firstname").SendKeys(customer.FirstName);
            Inputfields_textbox("lastname").SendKeys(customer.LastName);
            Inputfields_textbox("email_address").SendKeys(customer.Email);
            Inputfields_textbox("password").SendKeys(customer.Password);
            Inputfields_textbox("password-confirmation").SendKeys(customer.Password);
            Button("Create an Account", 3).Click();
        }

        #endregion
    }
}