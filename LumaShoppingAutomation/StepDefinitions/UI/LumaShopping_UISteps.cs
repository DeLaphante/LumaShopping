using CynkyUtilities;
using FluentAssertions;
using LumaShoppingAutomation.Models.UI;
using LumaShoppingAutomation.PageObjects.CommonPages;
using Reqnroll;

namespace LumaShoppingAutomation.StepDefinitions.UI
{
    [Binding]
    public class LumaShopping_UISteps
    {
        Navigation _Navigation;
        ItemsPage _ItemsPage;
        MyAccountPage _MyAccountPage;
        ShippingAddressPage _ShippingAddressPage;
        ReviewAndPaymentsPage _ReviewAndPaymentsPage;
        CreateNewCustomerAccountPage _CreateNewCustomerAccountPage;
        ScenarioContext _ScenarioContext;

        public LumaShopping_UISteps(ScenarioContext scenarioContext)
        {
            _Navigation = scenarioContext.ScenarioContainer.Resolve<Navigation>();
            _ItemsPage = scenarioContext.ScenarioContainer.Resolve<ItemsPage>();
            _ShippingAddressPage = scenarioContext.ScenarioContainer.Resolve<ShippingAddressPage>();
            _ReviewAndPaymentsPage = scenarioContext.ScenarioContainer.Resolve<ReviewAndPaymentsPage>();
            _MyAccountPage = scenarioContext.ScenarioContainer.Resolve<MyAccountPage>();
            _CreateNewCustomerAccountPage = scenarioContext.ScenarioContainer.Resolve<CreateNewCustomerAccountPage>();
            _ScenarioContext = scenarioContext.ScenarioContainer.Resolve<ScenarioContext>();
        }


        [StepDefinition(@"user is on the '(.*)' page")]
        public void GivenUserIsOnTheMensTopsPage(string page)
        {
            var customer = new Customer();
            _ScenarioContext.Set<Customer>(customer, "customer");
            _Navigation.NavigateToMenuOption(page, customer);
        }

        [StepDefinition(@"user adds items to the cart")]
        public void WhenUserAddsItemsToTheCart()
        {
            var customer = _ScenarioContext.Get<Customer>("customer");
            _ItemsPage.AddItemToCart(customer);
            StringGenerator.GetSanitizedAlphanumericString(_ItemsPage.GetNumberOfItemsInCart())
                .Should().Contain($"{_ItemsPage.GetTotalNumberOfItems(customer)}");
        }

        [StepDefinition(@"places the order")]
        public void WhenPlacesTheOrder()
        {
            _Navigation.NavigateToMenuOption("My cart");
            _Navigation.ClickButton("Proceed to Checkout");

            var customer = _ScenarioContext.Get<Customer>("customer");
            _ShippingAddressPage.EnterShippingAddress(customer);

            StringGenerator.GetSanitizedAlphanumericString(_ReviewAndPaymentsPage.
                GetBillingAddress().Replace("\r\n", string.Empty).Replace("Edit", string.Empty))
                .Should().Be($"{customer.FirstName}{customer.LastName}{customer.StreetAddress}{customer.City}{StringGenerator.GetSanitizedAlphanumericString(customer.Country)}{customer.PhoneNumber}");

            StringGenerator.GetSanitizedAlphanumericString(_ReviewAndPaymentsPage.
                GetShipToAddress().Replace("\r\n", string.Empty).Replace("Edit", string.Empty))
                .Should().Be($"{customer.FirstName}{customer.LastName}{customer.StreetAddress}{customer.City}{StringGenerator.GetSanitizedAlphanumericString(customer.Country)}{customer.PhoneNumber}");

            _Navigation.ClickButton("Place Order");
        }

        [StepDefinition(@"the order should be successfully placed")]
        public void ThenTheOrderShouldBeSuccessfullyPlaced()
        {
            StringGenerator.GetSanitizedAlphanumericString(_Navigation.GetPageHeader()).Should().Be("Thankyouforyourpurchase");

            _Navigation.GetCheckOutSuccessMessage().Should().ContainAny("Your order # is:");
        }

        [StepDefinition(@"user is on the Create New Customer Account page")]
        public void GivenUserIsOnTheCreateNewCustomerAccountPage()
        {
            _Navigation.NavigateToMenuOption("Create an Account");
            StringGenerator.GetSanitizedAlphanumericString(_Navigation.GetPageHeader()).Should().Be("CreateNewCustomerAccount");
        }

        [StepDefinition(@"the user creates an account")]
        public void WhenTheUserCreatesAnAccount()
        {
            var customer = new Customer();
            _ScenarioContext.Set<Customer>(customer, "customer");
            _CreateNewCustomerAccountPage.CreateAccount(customer);
        }

        [StepDefinition(@"the account should be successfully created")]
        public void ThenTheAccountShouldBeSuccessfullyCreated()
        {
            var customer = _ScenarioContext.Get<Customer>("customer");
            _MyAccountPage.GetContactInformation().Replace("\r\n", string.Empty)
                .Should().Be($"{customer.FirstName} {customer.LastName}{customer.Email}");
        }


    }
}
