using Contracts.Dto;
using Contracts;
using Mango.Web.Services;
using Mango.Web.Utility;
using Mango.Web.Models.Dto;

namespace Mango.Web.Service
{
    public class ProductService : IProductService
    {
        private readonly IBaseService _baseService;
        public ProductService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto> CreateProductsAsync(ProductDto productDto)
        {
            return await _baseService.SendAsync(new WebRequestDto()
            {
                ApiType = Constant.ApiType.POST,
                Data = productDto,
                Url = Constant.ProductAPIBase + "/api/product",
                ContentType = Constant.ContentType.MultipartFormData
            });
        }

        public async Task<ResponseDto> DeleteProductsAsync(int id)
        {
            return await _baseService.SendAsync(new WebRequestDto()
            {
                ApiType = Constant.ApiType.DELETE,
                Url = Constant.ProductAPIBase + "/api/product/" + id
            });
        }

        public async Task<ResponseDto> GetAllProductsAsync()
        {
            return await _baseService.SendAsync(new WebRequestDto()
            {
                ApiType = Constant.ApiType.GET,
                Url = Constant.ProductAPIBase + "/api/product"
            });
        }

        public async Task<ResponseDto> GetProductByIdAsync(int id)
        {
            return await _baseService.SendAsync(new WebRequestDto()
            {
                ApiType = Constant.ApiType.GET,
                Url = Constant.ProductAPIBase + "/api/product/" + id
            });
        }

        public async Task<ResponseDto> UpdateProductsAsync(ProductDto productDto)
        {
            return await _baseService.SendAsync(new WebRequestDto()
            {
                ApiType = Constant.ApiType.PUT,
                Data = productDto,
                Url = Constant.ProductAPIBase + "/api/product",
                ContentType = Constant.ContentType.MultipartFormData
            });
        }
    }
}