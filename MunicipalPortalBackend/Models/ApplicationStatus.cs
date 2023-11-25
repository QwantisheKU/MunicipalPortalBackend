namespace MunicipalPortalBackend.Models
{
	public class ApplicationStatus
	{
		public int Id { get; set; }

		public Status Status { get; set; }

		public string? Description { get; set; }

		public DateTime DateCreated { get; set; } = DateTime.UtcNow;

		public int ApplicationId { get; set; }

		public Application Application { get; set; }
	}
}
