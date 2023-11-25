namespace MunicipalPortalBackend.Dtos.AuthDtos
{
	public class UserToken : ResultResponse
	{
		public string AccessToken { get; set; }

		public string ExpiresIn { get; set; }

		public string TokenType { get; set; }
	}
}
