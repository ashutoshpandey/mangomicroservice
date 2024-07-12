using Contracts;
using Mango.Services.CouponAPI.Models.Dto;

namespace Mango.Web.Services
{
    public interface ICouponService
    {
        Task<ResponseDto> GetAllCouponsAsync();
        Task<ResponseDto> DeleteCouponAsync(int id);
        Task<ResponseDto> GetCouponByIdAsync(int id);
        Task<ResponseDto> GetCouponAsync(string couponCode);
        Task<ResponseDto> CreateCouponAsync(CouponDto couponDto);
        Task<ResponseDto> UpdateCouponAsync(CouponDto couponDto);
    }
}
