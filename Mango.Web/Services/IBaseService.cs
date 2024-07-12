using Mango.Web.Models;

namespace Mango.Web.Services
{
    public interface IBaseService
    {
        ResponseDto SendAsync(RequestDto requestDto);
    }
}
