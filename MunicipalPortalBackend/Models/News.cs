namespace MunicipalPortalBackend.Models
{
	public class News
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public int? CategoryId { get; set; }

		public Category? Category { get; set; }

		public List<Picture> Pictures { get; set; }
	}
}
