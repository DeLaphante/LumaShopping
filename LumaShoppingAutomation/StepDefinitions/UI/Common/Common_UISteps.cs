using LumaShoppingAutomation.PageObjects.CommonPages;
using TechTalk.SpecFlow;

namespace LumaShoppingAutomation.StepDefinitions.UI.Common
{
    [Binding]
    public sealed class Common_UISteps
    {
        Navigation _Navigation;

        public Common_UISteps(ScenarioContext scenarioContext)
        {
            _Navigation = scenarioContext.ScenarioContainer.Resolve<Navigation>();
        }

        [StepDefinition(@"user is on the homepage")]
        public void GivenUserNavigatesToTheHomePage()
        {
            _Navigation.NavigateToHomePage();
        }


    }
}
