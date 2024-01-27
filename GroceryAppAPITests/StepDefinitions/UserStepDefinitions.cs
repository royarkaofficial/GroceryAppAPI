using System;
using TechTalk.SpecFlow;

namespace GroceryAppAPITests.StepDefinitions
{
    [Binding]
    [Scope(Feature ="User")]
    public class UserStepDefinitions
    {
        [Given(@"I am a registered user")]
        public void GivenIAmARegisteredUser()
        {
            throw new PendingStepException();
        }

        [When(@"the user sends GET request to the '([^']*)' endpoint")]
        public void WhenTheUserSendsGETRequestToTheEndpoint(string p0)
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

        [When(@"the user sends PUT request to the '([^']*)' endpoint with the data '([^']*)'")]
        public void WhenTheUserSendsPUTRequestToTheEndpointWithTheData(string p0, string p1)
        {
            throw new PendingStepException();
        }
    }
}
