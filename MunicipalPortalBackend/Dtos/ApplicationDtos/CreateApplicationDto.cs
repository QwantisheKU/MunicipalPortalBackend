using MunicipalPortalBackend.Models;
using System.Text.Json.Serialization;

namespace MunicipalPortalBackend.Dtos.ApplicationDtos
{
	public class CreateApplicationDto
	{
		public string Description { get; set; }

		public string Address { get; set; }

		public double? Latitude { get; set; }

		public double? Longitude { get; set; }
	}
}
