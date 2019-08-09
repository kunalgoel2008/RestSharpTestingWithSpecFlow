using RestSharp;
using RestSharpTesting.Model;
using System;

namespace RestSharpTesting.Base
{
    public class Settings
    {
        public Uri BaseUrl { get; set; }
        public IRestResponse<User> Response { get; set; } 
        public IRestRequest Request { get; set; }
        public RestClient Client { get; set; } = new RestClient();

        public int StatusCode { get; set; }
        public string StatusCodeString { get; set; }
    }
}
