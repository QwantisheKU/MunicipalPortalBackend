using MunicipalPortalBackend.Models;

namespace MunicipalPortalBackend.Dtos.ApplicationStatusDtos
{
	public class ApplicationStatusDto
	{
		public Status Status { get; set; }

		public string? Description { get; set; }

		public DateTime DateCreated { get; set; }
	}
}
