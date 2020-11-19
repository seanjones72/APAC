using Newtonsoft.Json;
using RestSharp;
using RestSharpPOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpPOC
{
    public class Demo
    {
        private Helper helper;

        public Demo()
        {
            helper = new Helper();
        }


        public Users GetUsers()
        {
            var client = helper.SetUrl("api/users?page-2");
            var request = helper.CreateGetRequest();
            request.RequestFormat = DataFormat.Json;
            var response = helper.GetResponse(client, request);
            var users = HandleContent.GetContent<Users>(response);
            return users;
        }

            public CreateUserRes CreateNewUser(dynamic payload)
        {
            var client = helper.SetUrl("api/users");
            var jsonString = HandleContent.SerializeJsonString(payload);
            var request = helper.CreatePostRequest(jsonString);
            var response = helper.GetResponse(client, request);
            var createuser = HandleContent.GetContent<CreateUserRes>(response);
            return createuser;
        }
        
    }
}
