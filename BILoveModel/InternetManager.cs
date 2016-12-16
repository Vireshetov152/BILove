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
        private Dictionary<string, string> infoDict = new Dictionary<string, string>();
        public Dictionary<string, string> InfoDict
        {
            get { return infoDict; }
            set { infoDict = value; }
        }

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
    }
}