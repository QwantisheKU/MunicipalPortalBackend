namespace MunicipalPortalBackend.Dtos
{
	public class ResultResponse
	{
		public bool IsSuccess { get; set; }

		public string Message { get; set; }

		public List<string> Errors { get; set; }
	}
}
