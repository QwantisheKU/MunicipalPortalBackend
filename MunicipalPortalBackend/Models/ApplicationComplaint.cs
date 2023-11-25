namespace MunicipalPortalBackend.Models
{
	public class ApplicationComplaint
	{
		public int Id { get; set; }

		public string Text { get; set; }

		public DateTime DateCreated { get; set; } = DateTime.UtcNow;

		public int ApplicationId { get; set; }

		public Application Application { get; set; }
	}
}
