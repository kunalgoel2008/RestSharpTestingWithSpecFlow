using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharpTesting;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            RestSharpTesting.Features.GetAllUsersFeature test = new RestSharpTesting.Features.GetAllUsersFeature();
            test.AsAnApplicationUserWhenIFetchAllUserDetails();

        }
    }
}
