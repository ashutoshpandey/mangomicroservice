using Contracts;
using static Mango.Web.Utility.Constant;

namespace Mango.Web.Models.Dto
{
    public class WebRequestDto: RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
    }
}
