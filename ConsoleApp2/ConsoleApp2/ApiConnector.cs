using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class ApiConnector
    {
        public static void asd()
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://192.168.100.31:5000/users");
            httpWebRequest.Method = "GET";
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream stream = httpWebResponse.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string json = reader.ReadToEnd();

            Users? resp = JsonSerializer.Deserialize<Users>(json);
            foreach (User user in resp.users)
            {
                Console.WriteLine($"{user.PersonCode} {user.PersonRole} {user.LastSecurityPointNumber}");
            }
        } 
    }
    public class Users
    {
        public User[] users { get; set; }
    }
    public class User
    {
        public string LastSecurityPointDirection { get; set; }
        public int LastSecurityPointNumber { get; set; }
        public string LastSecurityPointTime { get; set; }
        public int PersonCode { get; set; }
        public int PersonRole { get; set; }
    }

 }