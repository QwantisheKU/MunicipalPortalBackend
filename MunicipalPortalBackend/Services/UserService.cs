using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MunicipalPortalBackend.Dtos;
using MunicipalPortalBackend.Dtos.AuthDtos;
using MunicipalPortalBackend.Models;
using MunicipalPortalBackend.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MunicipalPortalBackend.Services
{
	public class UserService : IUserService
	{
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		private readonly IConfiguration _config;
		private readonly IMapper _mapper;

		public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration config, IMapper mapper)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_config = config;
			_mapper = mapper;
		}

		public async Task<ResultResponse> RegisterUserAsync(RegisterUserDto registerUserDto)
		{
			if (registerUserDto == null)
			{
				return new ResultResponse
				{
					Message = "Некорректный запрос",
					IsSuccess = false
				};
			}

			var user = _mapper.Map<User>(registerUserDto);
			user.UserName = user.Email;

			var result = await _userManager.CreateAsync(user, registerUserDto.Password);

			if (result.Succeeded)
			{
				return new ResultResponse
				{
					Message = "Успешная регистрация",
					IsSuccess = true
				};
			}
			return new ResultResponse
			{
				Message = "Не удалось зарегистрировать пользователя",
				IsSuccess = false,
				Errors = result.Errors.Select(e => e.Description).ToList()
			};
		}

		public async Task<UserToken> LoginUserAsync(LoginUserDto loginUserDto)
		{
			if (loginUserDto == null)
			{
				return new UserToken
				{
					Message = "Некорректный запрос",
					IsSuccess = false
				};
			}

			var user = await _userManager.FindByEmailAsync(loginUserDto.Email);

			if (user == null)
			{
				return new UserToken
				{
					Message = "Пользователь не найден",
					IsSuccess = false
				};
			}

			var result = await _signInManager.CheckPasswordSignInAsync(user, loginUserDto.Password, false);

			if (result.Succeeded)
			{
				var token = await GenerateJwtToken(user);
				return token;
			}

			var errors = new List<string>();
			if (result.IsLockedOut)
			{
				errors.Add("Попытка авторизации заблокирована");
			}
			else if (result.IsNotAllowed)
			{
				errors.Add("Доступ заблокирован");
			}
			else if (result.RequiresTwoFactor)
			{
				errors.Add("Требуется двухфакторная аутентификация");
			}

			return new UserToken
			{
				Message = "Не удалось получить токен авторизации",
				IsSuccess = false,
				Errors = errors
			};
		}

		private async Task<UserToken> GenerateJwtToken(User user)
		{
			var claims = new List<Claim>
			{
				new Claim("Email", user.Email),
				new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
			};

			var roles = await _userManager.GetRolesAsync(user);
			claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AuthSettings:Token").Value));

			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.Now.AddHours(1),
				SigningCredentials = creds
			};

			var tokenHandler = new JwtSecurityTokenHandler();

			var token = tokenHandler.CreateToken(tokenDescriptor);

			var accessToken = tokenHandler.WriteToken(token);
			var expiresIn = TimeSpan.FromSeconds(3600).TotalSeconds.ToString();


			var tokenModel = new UserToken
			{
				AccessToken = accessToken,
				ExpiresIn = expiresIn,
				TokenType = "Bearer",
				IsSuccess = true
			};

			return tokenModel;
		}
	}
}
