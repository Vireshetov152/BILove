using BILoveModel.DTO;
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

        // Singleton pattern to initialize infoDict only once
        private static InternetManager instance = null;
        public static InternetManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new InternetManager();
                return instance;
            }
        }

        // Getting user info from vk and 'interests page'
        public void GetInterests(List<string> interests)
        { 
            infoDict.Add("interests", string.Join(",", interests.ToArray()));
        }

        public void GetVKInfo(List<string> userInfo)
        {
            infoDict.Add("userName", userInfo[0]);
            infoDict.Add("userPhoto", userInfo[1]);
        }

        // Post request
        public async void AddUser()
        {
            string values = "{\"UserName\":\"" + infoDict["userName"] + "\",\"UserPhotoUrl\":\"" + infoDict["userPhoto"] + "\",\"Interests\":\"" + infoDict["interests"] + "\",\"IsBusy\":\"0\"}";
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
                    UserId = int.Parse(item._id.id)
                }).ToList();
                return result;
            }
        }

        // Put request
        public async void ChangeUserData(User user)
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