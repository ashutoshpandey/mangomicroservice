using Contracts.Dto;
using Contracts;
using Mango.Web.Models.Dto;

namespace Mango.Web.Services
{
    public interface IProductService
    {
        Task<ResponseDto> GetAllProductsAsync();
        Task<ResponseDto> DeleteProductsAsync(int id);
        Task<ResponseDto> GetProductByIdAsync(int id);
        Task<ResponseDto> CreateProductsAsync(ProductDto productDto);
        Task<ResponseDto> UpdateProductsAsync(ProductDto productDto);
    }
}