using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BILoveModel.DTO
{
    public class ResultItem
    {
        public Id _id { get; set; }
        public string UserName { get; set; }
        public string UserPhotoUrl { get; set; }
        public string Interests { get; set; }
        public string IsBusy { get; set; }
        public string CoupleName { get; set; }
        public string IsMale { get; set; }
        public string PhotoId { get; set; }
    }

    public class Id
    {
        [JsonProperty("$"+"oid")]
        public string id { get; set; }
    }
}
