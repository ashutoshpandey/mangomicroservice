using Contracts;
using Mango.Web.Models.Dto;

namespace Mango.Web.Services
{
	public interface ICartService
	{
		Task<ResponseDto> EmailCart(CartDto cartDto);
		Task<ResponseDto> UpsertCartAsync(CartDto cartDto);
		Task<ResponseDto> ApplyCouponAsync(CartDto cartDto);
		Task<ResponseDto> GetCartByUserIdAsnyc(string userId);
		Task<ResponseDto> RemoveFromCartAsync(int cartDetailsId);
	}
}
