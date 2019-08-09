using RestSharp;
using RestSharpTesting.Base;
using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace RestSharpTesting.Hooks
{
    [Binding]
    public class TestInitialize
    {
        private Settings _settings;
        public TestInitialize(Settings settings)
        {
            _settings = settings;
        }

        [BeforeScenario]
        public void TestSetup()
        {
            _settings.BaseUrl = new Uri(ConfigurationManager.AppSettings["baseUrl"].ToString());
            _settings.Client.BaseUrl = _settings.BaseUrl;
        }

        //[AfterScenario]

        //public void CleanDB()
        //{
        //    _settings.Request = new RestRequest("getUsers", Method.GET);
        //    _settings.Response = _settings.Client.Execute<Posts>(_settings.Request);

        //    _settings.Request = new RestRequest("deleteUser", Method.DELETE);
        //    _settings.Request.AddUrlSegment("id", userID);


        //}
    }
}
