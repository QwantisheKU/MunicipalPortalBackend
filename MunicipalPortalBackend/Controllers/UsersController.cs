using Microsoft.AspNetCore.Mvc;
using MunicipalPortalBackend.Dtos.AuthDtos;
using MunicipalPortalBackend.Dtos;
using NuGet.Common;
using MunicipalPortalBackend.Services.Interfaces;

namespace MunicipalPortalBackend.Controllers
{
	[Route("v1/users")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserService _authService;

		public UsersController(IUserService authService)
		{
			_authService = authService;
		}

		[HttpPost("register")]
		public async Task<ActionResult<ResultResponse>> RegisterUser(RegisterUserDto registerUserDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			var result = await _authService.RegisterUserAsync(registerUserDto);

			if (result.IsSuccess)
			{
				return new ObjectResult(result) { StatusCode = StatusCodes.Status201Created };
			}

			return BadRequest(result);
		}

		[HttpPost("login")]
		public async Task<ActionResult<UserToken>> LoginUser(LoginUserDto loginUserDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			var result = await _authService.LoginUserAsync(loginUserDto);

			if (result.IsSuccess)
			{
				return Ok(result);
			}

			return NotFound(result);
		}
	}
}
