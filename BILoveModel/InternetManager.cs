using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BILoveModel
{
    class InternetManager
    {
        const string apiKey = "zK7bftiQKXwBOYZsIFIpiOfc_xuzBWDb";
        static string GetUsers()
        {
            return string.Format("https://api.mlab.com/api/1/databases/bilove/collections/Users?apiKey={0}", apiKey);
        }
    }
}