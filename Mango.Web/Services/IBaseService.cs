using Contracts;
using Mango.Web.Models.Dto;

namespace Mango.Web.Services
{
    public interface IBaseService
    {
        Task<ResponseDto> SendAsync(WebRequestDto requestDto);
    }
}
