using RestSharp;
using RestSharpTesting.Model;
using System;

namespace RestSharpTesting.Base
{
    public class Settings
    {
        public Uri BaseUrl { get; set; }
        public IRestResponse<User> Response { get; set; }
        public IRestResponse Response1 { get; set; }
        public IRestResponse<UserPost> ResponsePost { get; set; } 
        public IRestRequest Request { get; set; }
        public RestClient Client { get; set; } = new RestClient();
        public string EndPoint { get; set; }
        public int StatusCode { get; set; }
        public string StatusCodeString { get; set; }
        public int StatusCodeValue { get; set; }
        public dynamic user { get; set; }
        public User _user { get; set; }
        public dynamic Data { get; set; }
   

    }
}
