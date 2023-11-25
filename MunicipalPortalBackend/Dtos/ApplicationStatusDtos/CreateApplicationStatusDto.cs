using MunicipalPortalBackend.Models;

namespace MunicipalPortalBackend.Dtos.ApplicationStatusDtos
{
	public class CreateApplicationStatusDto
	{
		public Status Status { get; set; }

		public string? Description { get; set; }

		public int ApplicationId { get; set; }
	}
}
