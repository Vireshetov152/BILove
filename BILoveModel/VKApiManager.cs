using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;

namespace BILoveModel
{
    public class VKApiManager
    {
        VkApi vk = new VkApi();

        private static VKApiManager instance = null;
        public static VKApiManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new VKApiManager();
                return instance;
            }
        }
        public void VKAuthorization(string login, string password)
        {
            ulong appID = 5764856;                      
            string email = login;         
            string pass = password;               
            Settings scope = Settings.All;    

            vk.Authorize(new ApiAuthParams
            {
                ApplicationId = appID,
                Login = email,
                Password = pass,
                Settings = scope
            });

            var user = vk.Users.Get(vk.UserId.Value, ProfileFields.All);
            var userName = user.FirstName + " " + user.LastName;
            var isMale = user.Sex == VkNet.Enums.Sex.Male ? "1" : "0";
            var userPhotoUrl = user.Photo100.OriginalString;
            var photoId = user.PhotoId;

            InternetManager.Instance.GetVKInfo(new List<string> { userName, userPhotoUrl, isMale, photoId });
        }   

        public void VKWallPost(string message)
        {
            vk.Wall.Post(new WallPostParams
            {
                OwnerId = vk.UserId,
                Message = "Your couple is  " + message,
                Attachments = new MediaAttachment[] {
                    vk.Photo.GetById(new string[] { "248935456_456239065" })[0]
                }
            });
        }
    }
}
