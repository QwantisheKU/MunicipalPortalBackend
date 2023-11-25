namespace MunicipalPortalBackend.Models
{
	public class Application
	{
		public int Id { get; set; }

		public string Description { get; set; }

		public string Address { get; set; }

		public double Latitude { get; set; }

		public double Longitude { get; set; }

		public List<Picture>? Pictures { get; set; }

		public Status Status { get; set; } = Status.ToDo;

		public DateTime DateCreated { get; set; } = DateTime.UtcNow;

		public int? MunicipalDepartmentId { get; set; }

		public MunicipalDepartment? MunicipalDepartment { get; set; }

		public ApplicationComplaint? ApplicationComplaint { get; set; }

		public List<ApplicationStatus>? ApplicationStatuses { get; set; }
	}

	public enum Status
	{
		ToDo = 0,
		InProgress = 1,
		Resolved = 2,
		Closed = 3
	}

	public enum Type
	{
		All = 0,
		User = 1,
		Department = 2
	}
}
