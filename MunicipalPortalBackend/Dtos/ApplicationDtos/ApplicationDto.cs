using MunicipalPortalBackend.Dtos.ApplicationStatusDtos;
using MunicipalPortalBackend.Dtos.CategoryDtos;
using MunicipalPortalBackend.Dtos.MunicipalDepartmentDtos;
using MunicipalPortalBackend.Models;
using System.Text.Json.Serialization;

namespace MunicipalPortalBackend.Dtos.ApplicationDtos
{
	public class ApplicationDto
	{
		public int Id { get; set; }

		public string Description { get; set; }

		public string Address { get; set; }

		public double Latitude { get; set; }

		public double Longitude { get; set; }

		[JsonConverter(typeof(JsonStringEnumConverter))]
		public Status Status { get; set; }

		public MunicipalDepartmentDto MunicipalDepartmentDto { get; set; }

		public List<ApplicationStatusDto>? ApplicationStatuses { get; set; }
	}
}
