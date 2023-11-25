namespace MunicipalPortalBackend.Dtos.NewsDtos
{
	public class CreateNewsDto
	{
		public string Title { get; set; }

		public string Description { get; set; }

		public int? CategoryId { get; set; }
	}
}
