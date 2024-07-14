using Contracts.Dto.AuthAPI;
using Contracts.Dto;

namespace Mango.Services.AuthAPI.Services
{
	public interface IAuthService
	{
		Task<string> Register(RegistrationRequestDto registrationRequestDto);
		Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
		Task<bool> AssignRole(string email, string roleName);
	}
}
