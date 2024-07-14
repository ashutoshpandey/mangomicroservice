using Contracts.Dto.AuthAPI;
using Contracts.Dto;
using Contracts;
using Mango.Web.Services;
using Mango.Web.Utility;
using Mango.Web.Models.Dto;

namespace Mango.Web.Service
{
	public class AuthService : IAuthService
	{
		private readonly IBaseService _baseService;
		public AuthService(IBaseService baseService)
		{
			_baseService = baseService;
		}

		public async Task<ResponseDto> AssignRoleAsync(RegistrationRequestDto registrationRequestDto)
		{
			return await _baseService.SendAsync(new WebRequestDto()
			{
				ApiType = Constant.ApiType.POST,
				Data = registrationRequestDto,
				Url = Constant.AuthAPIBase + "/api/auth/AssignRole"
			});
		}

		public async Task<ResponseDto> LoginAsync(LoginRequestDto loginRequestDto)
		{
			return await _baseService.SendAsync(new WebRequestDto()
			{
				ApiType = Constant.ApiType.POST,
				Data = loginRequestDto,
				Url = Constant.AuthAPIBase + "/api/auth/login"
			}, withBearer: false);
		}

		public async Task<ResponseDto> RegisterAsync(RegistrationRequestDto registrationRequestDto)
		{
			return await _baseService.SendAsync(new WebRequestDto()
			{
				ApiType = Constant.ApiType.POST,
				Data = registrationRequestDto,
				Url = Constant.AuthAPIBase + "/api/auth/register"
			}, withBearer: false);
		}
	}
}