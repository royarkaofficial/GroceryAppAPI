using System;
using TechTalk.SpecFlow;

namespace GroceryAppAPITests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "Registration")]
    public class RegistrationStepDefinitions
    {
        [Given(@"I am a registered user")]
        public void GivenIAmARegisteredUser()
        {
            throw new PendingStepException();
        }

        [When(@"the user sends POST request to the '([^']*)' endpoint with the data '([^']*)'")]
        public void WhenTheUserSendsPOSTRequestToTheEndpointWithTheData(string registration, string p1)
        {
            throw new PendingStepException();
        }

        [Then(@"the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int p0)
        {
            throw new PendingStepException();
        }

        [Then(@"the response body should be '([^']*)'")]
        public void ThenTheResponseBodyShouldBe(string p0)
        {
            throw new PendingStepException();
        }
    }
}
