using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using page_framework;
using Sample.Features.Pages;

namespace Sample.Features.Steps
{
    [Binding]
    public class StepDefinition1
    {
        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            Page.IsOn<LoginPage>();
        }

        [When(@"I enter valid credentials")]
        public void WhenIEnterValidCredentials()
        {
            Page.On<LoginPage>().Username = "mlutton";
        }

        [Then(@"I should be logged in")]
        public void ThenIShouldBeLoggedIn()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
