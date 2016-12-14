using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet;
using VkNet.Enums.Filters;

namespace BILoveModel
{
    public class VKApiManager
    {
        Dictionary<string, string> infoDict = new Dictionary<string, string>();
        public Dictionary<string, string> VKAuthorization(string login, string password)
        {
            ulong appID = 5764856;                      
            string email = login;         
            string pass = password;               
            Settings scope = Settings.All;    

            var vk = new VkApi();
            vk.Authorize(new ApiAuthParams
            {
                ApplicationId = appID,
                Login = email,
                Password = pass,
                Settings = scope
            });

            var user = vk.Users.Get(vk.UserId.Value, ProfileFields.All);
            var userName = user.FirstName + " " + user.LastName;
            var userPhotoUrl = user.Photo100.OriginalString;

            infoDict.Add("userName", userName);
            infoDict.Add("userPhoto", userPhotoUrl);

            Console.WriteLine(infoDict["userPhoto"]);
            
            return infoDict;
        }   
    }
}
