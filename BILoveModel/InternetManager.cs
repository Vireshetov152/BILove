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
        const string apiKey = "zK7bftiQKXwBOYZsIFIpiOfc_xuzBWDb";
        
        static string GetUsers()
        {
            return string.Format("https://api.mlab.com/api/1/databases/bilove/collections/Users?apiKey={0}", apiKey);
        }

        public async Task<string> AddUser()
        {
            string values = "{\"user\":\"test\"," +
                  "\"password\":\"bla\"}";
            var content = new StringContent(values, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync($"https://api.mlab.com/api/1/databases/bilove/collectio..{apiKey}", content);
                var responseString = await response.Content.ReadAsStringAsync();

                return responseString;
            }
        }
    }
}