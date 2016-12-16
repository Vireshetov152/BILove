using BILoveModel.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BILoveModel
{
    public class Requests
    {
        private const string apiKey = "zK7bftiQKXwBOYZsIFIpiOfc_xuzBWDb";

        // Post request
        public async void AddUser()
        {
            string values = "{\"UserName\":\"" + InternetManager.Instance.InfoDict["userName"] + "\",\"UserPhotoUrl\":\"" + InternetManager.Instance.InfoDict["userPhoto"] + "\",\"Interests\":\"" + InternetManager.Instance.InfoDict["interests"] + "\",\"IsBusy\":\"0\"}";
            var content = new StringContent(values, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync($"https://api.mlab.com/api/1/databases/bilove/collections/Users?apiKey={apiKey}", content);
                var responseString = await response.Content.ReadAsStringAsync();
            }
        }

        // Get request
        public async Task<List<User>> GetUsers()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync($"https://api.mlab.com/api/1/databases/bilove/collections/Users?apiKey={apiKey}");
                var data = JsonConvert.DeserializeObject<List<ResultItem>>(response);
                var result = data.Select(item => new User
                {
                    UserName = item.UserName,
                    UserPhotoUrl = item.UserPhotoUrl,
                    Interests = item.Interests.Split(',').ToList(),
                    IsBusy = int.Parse(item.IsBusy),
                    UserId = item._id.id
                }).ToList();
                return result;
            }
        }

        // Put request
        public async void UpdateUserData(User user)
        {
            string values = "{\"UserName\":\"" + user.UserName + "\",\"UserPhotoUrl\":\"" + user.UserPhotoUrl + "\",\"Interests\":\"" + string.Join(",", user.Interests.ToArray()) + "\",\"IsBusy\":\"1\"}";
            var content = new StringContent(values, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = await client.PutAsync($"https://api.mlab.com/api/1/databases/bilove/collections/Users/{user.UserId}?apiKey={apiKey}", content);
                var responseString = await response.Content.ReadAsStringAsync();
            }
        }
    }
}
