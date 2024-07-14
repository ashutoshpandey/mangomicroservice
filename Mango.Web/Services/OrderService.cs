using Contracts;
using Mango.Web.Models;
using Mango.Web.Models.Dto;
using Mango.Web.Services;
using Mango.Web.Utility;

namespace Mango.Web.Service
{
    public class OrderService : IOrderService
    {
        private readonly IBaseService _baseService;
        public OrderService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateOrder(CartDto cartDto)
        {
            return await _baseService.SendAsync(new WebRequestDto()
            {
                ApiType = Constant.ApiType.POST,
                Data = cartDto,
                Url = Constant.OrderAPIBase + "/api/order/CreateOrder"
            });
        }

        public async Task<ResponseDto> CreateStripeSession(StripeRequestDto stripeRequestDto)
        {
            return await _baseService.SendAsync(new WebRequestDto()
            {
                ApiType = Constant.ApiType.POST,
                Data = stripeRequestDto,
                Url = Constant.OrderAPIBase + "/api/order/CreateStripeSession"
            });
        }

        public async Task<ResponseDto> GetAllOrder(string userId)
        {
            return await _baseService.SendAsync(new WebRequestDto()
            {
                ApiType = Constant.ApiType.GET,
                Url = Constant.OrderAPIBase + "/api/order/GetOrders?userId=" + userId
            });
        }

        public async Task<ResponseDto> GetOrder(int orderId)
        {
            return await _baseService.SendAsync(new WebRequestDto()
            {
                ApiType = Constant.ApiType.GET,
                Url = Constant.OrderAPIBase + "/api/order/GetOrder/" + orderId
            });
        }

        public async Task<ResponseDto> UpdateOrderStatus(int orderId, string newStatus)
        {
            return await _baseService.SendAsync(new WebRequestDto()
            {
                ApiType = Constant.ApiType.POST,
                Data = newStatus,
                Url = Constant.OrderAPIBase + "/api/order/UpdateOrderStatus/" + orderId
            });
        }

        public async Task<ResponseDto> ValidateStripeSession(int orderHeaderId)
        {
            return await _baseService.SendAsync(new WebRequestDto()
            {
                ApiType = Constant.ApiType.POST,
                Data = orderHeaderId,
                Url = Constant.OrderAPIBase + "/api/order/ValidateStripeSession"
            });
        }
    }
}