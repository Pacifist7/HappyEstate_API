using Microsoft.AspNetCore.Mvc;
using static HappyEstate_Utility.SD;

namespace HappyEstate_Web.Models
{
    public class APIRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
    }
}
