using Contracts.Dto.AuthAPI;
using Contracts.Dto;
using Contracts;

namespace Mango.Web.Services
{
	public interface IAuthService
	{
		Task<ResponseDto> LoginAsync(LoginRequestDto loginRequestDto);
		Task<ResponseDto> RegisterAsync(RegistrationRequestDto registrationRequestDto);
		Task<ResponseDto> AssignRoleAsync(RegistrationRequestDto registrationRequestDto);
	}
}
