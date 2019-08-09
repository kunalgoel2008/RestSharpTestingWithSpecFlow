using NUnit.Framework;
using RestSharp;
using RestSharpTesting.Base;
using RestSharpTesting.Model;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RestSharpTesting.Steps
{
    [Binding]
    class GetUserSteps
    {
        private Settings _settings;
        public GetUserSteps(Settings settings)
        {
            _settings = settings;
        }

        //public RestClient client = new RestClient("http://localhost:63812/");
        //public RestRequest request = new RestRequest();
        //public IRestResponse<Posts> response = new RestResponse<Posts>();

        [Given(@"As an application user, I fetch all users details")]
        public void GivenAsAnApplicationUserIFetchAllUsersDetails()
        {   
            var endPoint = "getAllUsers";
            _settings.Request = new RestRequest(endPoint, Method.GET);
            _settings.Response = _settings.Client.Execute<User>(_settings.Request);
            //Console.WriteLine(_settings.Response.Data.id);
        }

        [Then(@"I should receive all available users")]
        public void ThenIShouldReceiveAllAvailableUsers()
        {
            string key = "StatusCode";
            int value = 200;
            _settings.StatusCode = (int)_settings.Response.StatusCode;
            Assert.That(_settings.StatusCode, Is.EqualTo(value), $"The {key} is not {value}");

        }

        [Given(@"As an application user, I fetch details of user with Id (.*)")]
        public void GivenAsAnApplicationUserIFetchDetailsOfUserWithId(string userID)
        {
            var endPoint = "getUsers/{id}";
            _settings.Request = new RestRequest(endPoint, Method.GET);
            _settings.Request.AddUrlSegment("id", userID);
            _settings.Response = _settings.Client.Execute<User>(_settings.Request);//.GetAwaiter().GetResult();
        }

        [Then(@"I should receive the First Name as ""(.*)""")]
        public void ThenIShouldReceiveTheFirstNameAs(string firstName)
        {
            string key = "StatusCode";
            int value = 200;
            //Console.WriteLine(_settings.Response.Data.first_name);
            _settings.StatusCode = (int)_settings.Response.StatusCode;
            Assert.That(_settings.StatusCode, Is.EqualTo(value), $"The {key} is not {value}");
            Assert.That(_settings.Response.Data.FirstName, Is.EqualTo(firstName), $"The first name is not associated with the provided id");
        }

        [Then(@"I should not receive the user with that id")]
        public void ThenIShouldNotReceiveTheUserWithThatId()
        {
            string key = "StatusCode";
            int value = 400;
            _settings.StatusCode = (int)_settings.Response.StatusCode;
            Assert.That(_settings.StatusCode, Is.EqualTo(value), $"The {key} is not {value}");
        }

        [Given(@"As an application user, I will enter the below details")]
        public void GivenAsAnApplicationUserIWillEnterTheBelowDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            var endPoint = "createUser";
            _settings.Request = new RestRequest(endPoint, Method.POST);
            _settings.Request.RequestFormat = DataFormat.Json;
            _settings.Request.AddBody(new User()
            {
                Id = data.id,
                FirstName = data.first_name.ToString(),
                LastName = data.last_name.ToString(),
                PositionId = data.position_id,
                OrganisationId = data.organisation_id,
                AddressID = data.address_id,
                MobileNo = data.mob_no.ToString(),
                Alt_MobNo = data.alt_mob_no.ToString(),
                Email = data.email.ToString(),
                isDeleted = data.isDeleted,
                address = new Address()
                {
                    Id = data.add_id,
                    AddressType = data.add_type,
                    Street1 = data.street_1,
                    Street2 = data.street_2,
                    StateId = data.street_id,
                    Pincode = data.pin_code.ToString()
                }

            });
            _settings.Response = _settings.Client.Execute<User>(_settings.Request);

        }

        [Then(@"I should get a ""(.*)"" response")]
        public void ThenIShouldGetAResponse(string status)
        {
            _settings.StatusCodeString = _settings.Response.StatusCode.ToString();
            Assert.That(_settings.StatusCodeString, Is.EqualTo(status), $"The Status is not correct");
        }

        [Given(@"As an application user, I will not enter any detail")]
        public void GivenAsAnApplicationUserIWillNotEnterAnyDetail()
        {
            var endPoint = "createUser";
            _settings.Request = new RestRequest(endPoint, Method.POST);
            _settings.Request.RequestFormat = DataFormat.Json;
            _settings.Request.AddBody(null);
            _settings.Response = _settings.Client.Execute<User>(_settings.Request);
        }

        









        [Given(@"I perform GET operation for ""(.*)""")]
        public void GivenIPerformGETOperationFor(string url)
        {
            _settings.Request = new RestRequest(url, Method.GET);
        }

        [Given(@"I perform operation for ID ""(.*)""")]
        public void GivenIPerformOperationForID(String userID)
        {
            _settings.Request.AddUrlSegment("id", userID);
            _settings.Response = _settings.Client.Execute<User>(_settings.Request);// GetAwaiter().GetResult();
        }



        [Given(@"I execute operation")]
        public void GivenIPerformGETOperation()
        {
            _settings.Response = _settings.Client.Execute<User>(_settings.Request);
        }

        [Given(@"I perform POST operation for ""(.*)""")]
        public void GivenIPerformPOSTOperationFor(string url)
        {
            _settings.Request = new RestRequest(url, Method.POST);
        }


    }
}
