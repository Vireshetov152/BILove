using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BILoveModel
{
    public class User
    {
        public string UserName { get; set; }
        public string UserPhotoUrl { get; set; }
        public List<string> Interests { get; set; }
        public int IsBusy { get; set; }
        public string UserId { get; set; }
    }
}
