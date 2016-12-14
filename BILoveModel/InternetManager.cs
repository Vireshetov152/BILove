using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BILoveModel
{
    public class InternetManager
    {
        private const string apiKey = "zK7bftiQKXwBOYZsIFIpiOfc_xuzBWDb";
        private Dictionary<string, string> infoDict = new Dictionary<string, string>();

        // Getting user info vk and 'interests page'
        public void GetInterests(List<string> interests) 
        {
            infoDict.Add("interests", string.Join(",", interests.ToArray()));
        }

        public void GetVKInfo(string name, string photoUrl)
        {
            infoDict.Add("userName", name);
            infoDict.Add("userPhoto", photoUrl);
        }
        static string GetUsers()
        {
            return string.Format("https://api.mlab.com/api/1/databases/bilove/collections/Users?apiKey={0}", apiKey);
        }

        public async Task<string> AddUser()
        {
            string values = "{\"UserInfo\":\"test\"," +
                  "\"password\":\"bla\"}";
            var content = new StringContent(values, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync($"https://api.mlab.com/api/1/databases/bilove/collections/Users?apiKey={apiKey}", content);
                var responseString = await response.Content.ReadAsStringAsync();

                return responseString;
            }
        }
    }
}