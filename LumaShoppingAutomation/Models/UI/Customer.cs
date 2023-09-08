using CynkyUtilities;
using System.Collections.Generic;

namespace LumaShoppingAutomation.Models.UI
{
    public class Customer
    {
        public string FirstName { get; set; } = StringGenerator.GetRandomString();
        public string LastName { get; set; } = StringGenerator.GetRandomString();
        public string Email { get; set; } = StringGenerator.GetRandomEmail("mailinator.com");
        public string Password { get; set; } = StringGenerator.GetRandomString() + "@1";
        public string StreetAddress { get; set; } = StringGenerator.GetRandomString();
        public string City { get; set; } = "London";
        public string Country { get; set; } = "United Kingdom";
        public string PhoneNumber { get; set; } = StringGenerator.GetRandomUkMobileNumber();
        public string ShoppingGender { get; set; } = "Men";
        public List<string> ItemsColor { get; set; } = new List<string>() { "Black", "Yellow" };
        public string ItemsSize { get; set; } = "M";

    }
}
