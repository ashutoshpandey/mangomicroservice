using Mango.Web.Utility;
using static Mango.Web.Utility.Constant;

namespace Mango.Web.Models
{
    public class RequestDto
    {
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
        public ApiType ApiType { get; set; } = ApiType.GET;
    }
}
