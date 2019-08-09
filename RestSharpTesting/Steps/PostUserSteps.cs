using NUnit.Framework;
using RestSharp;
using RestSharpTesting.Base;
using RestSharpTesting.Model;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RestSharpTesting.Steps
{
    [Binding]
    class PostUserSteps
    {
        private Settings _settings;
        public PostUserSteps(Settings settings)
        {
            _settings = settings;
        }
        [Given(@"I perform POST operation for ""(.*)"" with body")]
        public void GivenIPerformPOSTOperationForWithBody(string url, Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            _settings.Request = new RestRequest(url, Method.POST);
            _settings.Request.RequestFormat = DataFormat.Json;
            _settings.Request.AddBody(new User() {
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

        [Then(@"I should see the ""(.*)"" For POST as ""(.*)""")]
        public void ThenIShouldSeeTheForPOSTAs(string key, int value)
        {
            _settings.StatusCode = (int)_settings.Response.StatusCode;
            Assert.That(_settings.StatusCode, Is.EqualTo(value), $"The {key} is not {value}");
        }

        [Given(@"I perform POST operation for ""(.*)"" without body")]
        public void GivenIPerformPOSTOperationForWithoutBody(string url)
        {
            _settings.Request = new RestRequest(url, Method.POST);
            _settings.Request.RequestFormat = DataFormat.Json;
            _settings.Request.AddBody(null);
            _settings.Response = _settings.Client.Execute<User>(_settings.Request);

        }

        [Given(@"I perform GET operation for ""(.*)"" without body")]
        public void GivenIPerformGETOperationForWithoutBody(string url)
        {
            _settings.Request = new RestRequest(url, Method.GET);
            _settings.Response = _settings.Client.Execute<User>(_settings.Request);

        }


        [Given(@"I perform GET operation for ""(.*)"" with body")]
        public void GivenIPerformGETOperationForWithBody(string url, Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            _settings.Request = new RestRequest(url, Method.GET);
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
                    Id = 15,
                    AddressType = "6411641C-F93C-4923-8D28-21FD0F36ADD6",
                    Street1 = "string",
                    Street2 = "string",
                    StateId = 1,
                    Pincode = "string"
                }

            });
            _settings.Response = _settings.Client.Execute<User>(_settings.Request);
        }

        

    }
}
