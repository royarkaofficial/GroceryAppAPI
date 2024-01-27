using GroceryAppAPI;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Text;

namespace GroceryAppAPITests.StepDefinitions
{
    /// <summary>
    /// Base class for all other step definitions.
    /// </summary>
    public class BaseStepDefinitions
    {
        private HttpClient _client;
        private HttpResponseMessage _response;
        private readonly WebApplicationFactory<TestStartup> _applicationFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseStepDefinitions"/> class.
        /// </summary>
        /// <param name="applicationFactory">The application factory.</param>
        public BaseStepDefinitions(WebApplicationFactory<TestStartup> applicationFactory)
        {
            _applicationFactory = applicationFactory;
        }

        [Given(@"I am a registered user")]
        public void GivenIAmARegisteredUser()
        {
            _client = _applicationFactory.CreateClient(new WebApplicationFactoryClientOptions()
            {
                BaseAddress = new Uri("http://localhost/")
            });
        }

        [When(@"the user sends GET request to the '([^']*)' endpoint")]
        public async Task WhenTheUserSendsGETRequestToTheEndpoint(string endpoint)
        {
            _response = await _client.GetAsync(GetUri(endpoint));
        }

        [When(@"the user sends POST request to the '([^']*)' endpoint with the data '([^']*)'")]
        public async Task WhenTheUserSendsPOSTRequestToTheEndpointWithTheData(string endpoint, string payload)
        {
            _response = await _client.PostAsync(GetUri(endpoint), GetRequestBody(payload));
        }

        [When(@"the user sends PUT request to the '([^']*)' endpoint with the data '([^']*)'")]
        public async Task WhenTheUserSendsPUTRequestToTheEndpointWithTheData(string endpoint, string payload)
        {
            _response = await _client.PutAsync(GetUri(endpoint), GetRequestBody(payload));
        }

        [When(@"the user sends DELETE request to the '([^']*)' endpoint")]
        public async Task WhenTheUserSendsDELETERequestToTheEndpoint(string endpoint)
        {
            _response = await _client.DeleteAsync(GetUri(endpoint));
        }

        [Then(@"the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int expectedStatusCode)
        {
            Assert.AreEqual(expectedStatusCode, (int)_response.StatusCode);
        }

        [Then(@"the response body should be '([^']*)'")]
        public async Task ThenTheResponseBodyShouldBe(string expectedBody)
        {
            var responseBody = await _response.Content.ReadAsStringAsync();
            Assert.AreEqual(expectedBody, responseBody);
        }

        /// <summary>
        /// Gets the URI.
        /// </summary>
        /// <param name="endpoint">The endpoint.</param>
        /// <returns>The URI.</returns>
        private Uri GetUri(string endpoint)
        {
            endpoint = $"/{endpoint}";
            return new Uri(endpoint, UriKind.Relative);
        }

        /// <summary>
        /// Gets the request body.
        /// </summary>
        /// <param name="payload">The payload.</param>
        /// <returns>The request body.</returns>
        private StringContent GetRequestBody(string payload)
        {
            return new StringContent(payload, Encoding.UTF8, "application/json");
        }
    }
}
