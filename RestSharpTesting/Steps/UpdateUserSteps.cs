using NUnit.Framework;
using RestSharp;
using RestSharpTesting.Base;
using RestSharpTesting.Model;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RestSharpTesting.Steps
{
    [Binding]
    class UpdateUserSteps
    {

        private Settings _settings;
        public UpdateUserSteps(Settings settings)
        {
            _settings = settings;
        }
        
        [Given(@"I perform PUT operation with ID ""(.*)""")]
        public void GivenIPerformPUTOperationFor(string id)
        {
            _settings.Request = new RestRequest("updateUser/" + id, Method.PUT);
        }

        /*        [Given(@"I will update user with ID ""(.*)""")]
        public void GivenIWillUpdateUserWithID(String userID)
        {
            _settings.Request.AddUrlSegment("id", userID);
        }
*/
        [Given(@"I will give the new body")]
        public void GivenIWillGiveTheNewBody(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

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
            _settings.Response = _settings.Client.Put<User>(_settings.Request);

        }

        [Then(@"I should see the ""(.*)"" after UPDATE as ""(.*)""")]
        public void ThenIShouldSeeTheAfterUPDATEAs(string key, int value)
        {
            _settings.StatusCode = (int)_settings.Response.StatusCode;
            Assert.That(_settings.StatusCode, Is.EqualTo(value), $"The {key} is not {value}");
        }

    }
}
