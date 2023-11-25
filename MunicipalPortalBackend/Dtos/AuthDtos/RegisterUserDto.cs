using System.ComponentModel.DataAnnotations;

namespace MunicipalPortalBackend.Dtos.AuthDtos
{
	public class RegisterUserDto
	{
		[Required(ErrorMessage = "Email обязателен для заполнения")]
		[EmailAddress(ErrorMessage = "Некорректный Email адрес")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Пароль обязателен для заполнения")]
		[StringLength(32, MinimumLength = 6, ErrorMessage = "Необходимо ввести пароль длиной от 6 до 32 символов")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "Пароль обязателен для заполнения")]
		[StringLength(32, MinimumLength = 6, ErrorMessage = "Необходимо ввести пароль длиной от 6 до 32 символов")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Пароли не совпадают")]
		public string PasswordConfirmation { get; set; }

		public int? MunicipalDepartmentId { get; set; }
	}
}
