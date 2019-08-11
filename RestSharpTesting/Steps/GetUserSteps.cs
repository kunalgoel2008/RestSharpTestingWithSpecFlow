using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using RestSharpTesting.Base;
using RestSharpTesting.Model;
using System;
using System.Collections.Generic;
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

     
        [Given(@"As an application user, I fetch all users details")]
        public void GivenAsAnApplicationUserIFetchAllUsersDetails()
        {   
            _settings.EndPoint = "getAllUsers";
            _settings.Request = new RestRequest(_settings.EndPoint, Method.GET);
            _settings.Response1 = _settings.Client.Execute(_settings.Request);
            _settings.user = new JsonDeserializer().Deserialize<List<dynamic>>(_settings.Response1);

            foreach (var userDetails in _settings.user)
            {
                var _user1 = new User()
                {
                    Id = Convert.ToInt32(userDetails["Id"]),
                    FirstName = (userDetails["FirstName"])
                };
            }
        }

        [Then(@"I should receive all available users")]
        public void ThenIShouldReceiveAllAvailableUsers()
        {
            _settings.StatusCodeValue = 200;
            _settings.StatusCode = (int)_settings.Response1.StatusCode;
            Assert.That(_settings.StatusCode, Is.EqualTo(_settings.StatusCodeValue), $"The Status Code is not {_settings.StatusCodeValue}");

        }

        [Given(@"As an application user, I fetch details of user with Id ""(.*)""")]
        public void GivenAsAnApplicationUserIFetchDetailsOfUserWithId(string userID)
        {
            _settings.EndPoint = "getUsers/{id}";
            _settings.Request = new RestRequest(_settings.EndPoint, Method.GET);
            _settings.Request.AddUrlSegment("id", userID);
            _settings.Response1 = _settings.Client.Execute(_settings.Request);
            _settings.StatusCodeString = _settings.Response1.StatusCode.ToString();
            if (!_settings.StatusCodeString.Equals("BadRequest"))
            {
                _settings.user = new JsonDeserializer().Deserialize<dynamic>(_settings.Response1);

                _settings._user = new User()
                {
                    Id = Convert.ToInt32(_settings.user["id"]),
                    FirstName = _settings.user["first_name"],
                    LastName = _settings.user["first_name"],
                    PositionId = Convert.ToInt32(_settings.user["position_id"]),
                    MobileNo = _settings.user["mob_no"],
                    Alt_MobNo = _settings.user["alt_mob_no"],
                    Email = _settings.user["email"],
                    isDeleted = Convert.ToBoolean(_settings.user["isDeleted"]),
                    address = new Address()
                    {
                        Id = _settings.user["address"]["id"],
                    }


                };
             }
        }

        [Then(@"I should receive the First Name as ""(.*)""")]
        public void ThenIShouldReceiveTheFirstNameAs(string firstName)
        {
            _settings.StatusCodeValue = 200;
            _settings.StatusCode = (int)_settings.Response1.StatusCode;
            Assert.That(_settings.StatusCode, Is.EqualTo(_settings.StatusCodeValue), $"The StatusCOde is not {_settings.StatusCodeValue}");
            Assert.That(_settings._user.FirstName, Is.EqualTo(firstName), $"The first name is not associated with the provided id");
        }

        [Then(@"I should not receive the user with that id")]
        public void ThenIShouldNotReceiveTheUserWithThatId()
        {
            _settings.StatusCodeValue = 400;
            _settings.StatusCode = (int)_settings.Response1.StatusCode;
            Assert.That(_settings.StatusCode, Is.EqualTo(_settings.StatusCodeValue), $"The StatusCode is not {_settings.StatusCodeValue}");
        }

        [Given(@"As an application user, I will enter the below details")]
        public void GivenAsAnApplicationUserIWillEnterTheBelowDetails(Table table)
        {
            _settings.Data = table.CreateDynamicInstance();
            _settings.EndPoint = "createUser";
            _settings.Request = new RestRequest(_settings.EndPoint, Method.POST);
            _settings.Request.RequestFormat = DataFormat.Json;
            _settings.Request.AddBody(new UserPost()
            {
                Id = _settings.Data.id,
                First_Name = _settings.Data.first_name,
                Last_Name = _settings.Data.last_name.ToString(),
                Position_Id = _settings.Data.position_id,
                Organisation_Id = _settings.Data.organisation_id,
                Address_ID = _settings.Data.address_id,
                Mob_No = _settings.Data.mob_no.ToString(),
                Alt_Mob_No = _settings.Data.alt_mob_no.ToString(),
                Email = _settings.Data.email.ToString(),
                isDeleted = _settings.Data.isDeleted,
                address = new Address1()
                {
                    Id = _settings.Data.add_id,
                    Address_Type = _settings.Data.add_type,
                    Street = _settings.Data.street_1,
                    Street_2 = _settings.Data.street_2,
                    State_Id = _settings.Data.street_id,
                    Pincode = _settings.Data.pin_code.ToString()
                }

            });
            _settings.ResponsePost = _settings.Client.Execute<UserPost>(_settings.Request);

        }

        [Then(@"I should get a ""(.*)"" response")]
        public void ThenIShouldGetAResponse(string status)
        {
            _settings.StatusCodeString = _settings.ResponsePost.StatusCode.ToString();
            Assert.That(_settings.StatusCodeString, Is.EqualTo(status), $"The Status is not correct");
        }

        [Given(@"As an application user, I will not enter any detail")]
        public void GivenAsAnApplicationUserIWillNotEnterAnyDetail()
        {
            _settings.EndPoint = "createUser";
            _settings.Request = new RestRequest(_settings.EndPoint, Method.POST);
            _settings.Request.RequestFormat = DataFormat.Json;
            _settings.Request.AddBody(null);
            _settings.ResponsePost = _settings.Client.Execute<UserPost>(_settings.Request);
        }

        [Given(@"As an application user, I fetch details of the created user")]
        public void GivenAsAnApplicationUserIFetchDetailsOfTheCreatedUser()
        {
            _settings.EndPoint = "getAllUsers";
            _settings.Request = new RestRequest(_settings.EndPoint, Method.GET);
            _settings.Response1 = _settings.Client.Execute(_settings.Request);
            _settings.user = new JsonDeserializer().Deserialize<List<dynamic>>(_settings.Response1);

            foreach (var userDetails in _settings.user)
            {
                _settings._user = new User()
                {

                    Id = Convert.ToInt32(userDetails["Id"]),
                    FirstName = userDetails["FirstName"],
                    LastName = userDetails["LastName"],
                    //PositionId = Convert.ToInt32(userDetails["PositionID"]),
                    MobileNo = userDetails["MobileNo"],
                    //Alt_MobNo = userDetails["Alt_MobNO"],
                    Email = userDetails["Email"],
                    isDeleted = Convert.ToBoolean(userDetails["isDeleted"]),
                };
                
            }
        }

        [Then(@"I should get the correct details")]
        public void ThenIShouldGetTheCorrectDetails()
        {
            if (_settings._user.FirstName.Equals(_settings.Data.first_name))
            {
                _settings.StatusCodeValue = 200;
                _settings.StatusCode = (int)_settings.Response1.StatusCode;
                Assert.That(_settings.StatusCode, Is.EqualTo(_settings.StatusCodeValue), $"The Status Code is not {_settings.StatusCodeValue}");
                Assert.That(_settings._user.FirstName, Is.EqualTo(_settings.Data.first_name), $"The First Name is not correct");
                Assert.That(_settings._user.LastName, Is.EqualTo(_settings.Data.last_name.ToString()), $"The Last Name is not correct");
                Assert.That(_settings._user.MobileNo, Is.EqualTo(_settings.Data.mob_no.ToString()), $"The Mobile number is not correct");
                Assert.That(_settings._user.Email, Is.EqualTo(_settings.Data.email.ToString()), $"The Email ID is not correct");

            }
        }

        [Given(@"As an application user, I delete the user with id ""(.*)""")]
        public void GivenAsAnApplicationUserIDeleteTheUserWithId(string userID)
        {
            _settings.EndPoint = "deleteUsers/{id}";
            _settings.Request = new RestRequest(_settings.EndPoint, Method.DELETE);
            _settings.Request.AddUrlSegment("id", userID);
            _settings.Response = _settings.Client.Execute<User>(_settings.Request);

        }

        [Then(@"The user should be deleted")]
        public void ThenTheUserShouldBeDeleted()
        {
            _settings.StatusCodeValue = 200;
            _settings.StatusCode = (int)_settings.Response.StatusCode;
            Assert.That(_settings.StatusCode, Is.EqualTo(_settings.StatusCodeValue), $"The StatusCode is not {_settings.StatusCodeValue}");
        }
    }
}
