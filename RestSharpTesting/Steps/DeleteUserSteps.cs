using NUnit.Framework;
using RestSharp;
using RestSharpTesting.Base;
using RestSharpTesting.Model;
using System;
using TechTalk.SpecFlow;

namespace RestSharpTesting.Steps
{
    [Binding]
    class DeleteUserSteps
    {
        private Settings _settings;
        public DeleteUserSteps(Settings settings)
        {
            _settings = settings;
        }
        [Given(@"I perform DELETE operation for ""(.*)""")]
        public void GivenIPerformDELETEOperationFor(string url)
        {
            _settings.Request = new RestRequest(url, Method.DELETE);
        }

        [Given(@"I perform operation to ID ""(.*)""")]
        public void GivenIPerformOperationToID(String userID)
        {
            _settings.Request.AddUrlSegment("id", userID);
            _settings.Response = _settings.Client.Execute<User>(_settings.Request);
        }

        [Then(@"I should see the ""(.*)"" for DELETE as ""(.*)""")]
        public void ThenIShouldSeeTheForDELETEAs(string key, int value)
        {
            _settings.StatusCode = (int)_settings.Response.StatusCode;
            Assert.That(_settings.StatusCode, Is.EqualTo(value), $"The {key} is not {value}");
        }

    }
}
