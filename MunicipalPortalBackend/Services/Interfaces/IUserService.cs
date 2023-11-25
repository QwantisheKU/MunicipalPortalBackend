using MunicipalPortalBackend.Dtos;
using MunicipalPortalBackend.Dtos.AuthDtos;

namespace MunicipalPortalBackend.Services.Interfaces
{
	public interface IUserService
	{
		Task<ResultResponse> RegisterUserAsync(RegisterUserDto registerUserDto);
		Task<UserToken> LoginUserAsync(LoginUserDto loginUserDto);
	}
}
