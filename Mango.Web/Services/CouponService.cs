using Contracts;
using Mango.Services.CouponAPI.Models.Dto;
using Mango.Web.Models.Dto;
using Mango.Web.Utility;

namespace Mango.Web.Services
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;

        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto> CreateCouponAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new WebRequestDto()
            {
                ApiType = Constant.ApiType.POST,
                Url = Constant.CouponAPIBase + "/api/coupon",
                Data = couponDto
            });
        }

        public async Task<ResponseDto> DeleteCouponAsync(int id)
        {
            return await _baseService.SendAsync(new WebRequestDto()
            {
                ApiType = Constant.ApiType.DELETE,
                Url = Constant.CouponAPIBase + "/api/coupon/" + id
            });
        }

        public async Task<ResponseDto> GetAllCouponsAsync()
        {
            return await _baseService.SendAsync(new WebRequestDto()
            {
                ApiType = Constant.ApiType.GET,
                Url = Constant.CouponAPIBase + "/api/coupon"
            });
        }

        public async Task<ResponseDto> GetCouponAsync(string couponCode)
        {
            return await _baseService.SendAsync(new WebRequestDto()
            {
                ApiType = Constant.ApiType.GET,
                Url = Constant.CouponAPIBase + "/api/coupon/GetByCode/" + couponCode
            });
        }

        public async Task<ResponseDto> GetCouponByIdAsync(int id)
        {
            return await _baseService.SendAsync(new WebRequestDto()
            {
                ApiType = Constant.ApiType.GET,
                Url = Constant.CouponAPIBase + "/api/coupon/" + id
            });
        }

        public async Task<ResponseDto> UpdateCouponAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new WebRequestDto()
            {
                ApiType = Constant.ApiType.PUT,
                Url = Constant.CouponAPIBase + "/api/coupon/" + couponDto.CouponId,
                Data = couponDto
            });
        }
    }
}
