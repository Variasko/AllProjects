using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WpfApp2
{
    internal  class APIConnector
    {
        static readonly HttpClient client = new HttpClient();
        private static User[] user;

        static async Task GetUser()
        {
            var responseString = await client.GetStringAsync("http://192.168.100.31:5000/users");
            var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseString);

            user = apiResponse.Users;

            getUserss();
            
        }
        static User[] getUserss()
        {
            return user;
        }
    }
    public class User
    {
        public string LastSecurityPointDirection { get; set; }
        public int LastSecurityPointNumber { get; set; }
        public string LastSecurityPointTime { get; set; }
        public int PersonCode { get; set; }
        public string PersonRole { get; set; }
    }

    public class ApiResponse
    {
        public User[] Users { get; set; }
    }
}
