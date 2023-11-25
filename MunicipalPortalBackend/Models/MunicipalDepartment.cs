namespace MunicipalPortalBackend.Models
{
	public class MunicipalDepartment
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string? Description { get; set; }

		public List<Application>? Applications { get; set; }

		public List<MunicipalDepartmentReview> DepartmentReviews { get; set; }
	}
}
