namespace MunicipalPortalBackend.Models
{
	public class MunicipalDepartmentReview
	{
		public int Id { get; set; }

		public double Rating { get; set; }

		public string Text { get; set; }

		public DateTime DateCreated { get; set; } = DateTime.UtcNow;

		public int MunicipalDepartmentId { get; set; }

		public MunicipalDepartment MunicipalDepartment { get; set; }
	}
}
