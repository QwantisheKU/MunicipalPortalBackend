using Microsoft.AspNetCore.Mvc;
using MunicipalPortalBackend.Dtos.MunicipalDepartmentDtos;
using MunicipalPortalBackend.Services;
using MunicipalPortalBackend.Services.Interfaces;
using System.Text.Json;

namespace MunicipalPortalBackend.Controllers
{
	[Route("v1")]
	[ApiController]
	public class LocationsController : ControllerBase
	{
		private readonly ILocationService _locationService;

		public LocationsController(ILocationService locationService)
		{
			_locationService = locationService;
		}

		[HttpPost("dadata/clean/address")]
		public async Task<ActionResult<JsonElement>> CleanAddress(string[] address)
		{
			var cleanedAddress = await _locationService.CleanAddress(address);

			/*if (cleanedAddress.)
			{
				return NotFound();
			}*/

			return Ok(cleanedAddress);
		}
	}
}
