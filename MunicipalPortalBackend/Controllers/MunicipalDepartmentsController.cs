using Microsoft.AspNetCore.Mvc;
using MunicipalPortalBackend.Dtos.MunicipalDepartmentDtos;
using MunicipalPortalBackend.Services.Interfaces;

namespace MunicipalPortalBackend.Controllers
{
	[Route("v1/municipal-departments")]
	[ApiController]
	public class MunicipalDepartmentsController : ControllerBase
	{
		private readonly IMunicipalDepartmentService _municipalDepartmentService;
		public MunicipalDepartmentsController(IMunicipalDepartmentService municipalDepartmentService)
		{
			_municipalDepartmentService = municipalDepartmentService;
		}

		[HttpGet]
		public async Task<ActionResult<List<MunicipalDepartmentDto>>> GetDepartments()
		{
			var municipalDepartments = await _municipalDepartmentService.GetAllAsync();

			if (municipalDepartments == null || !municipalDepartments.Any())
			{
				return NotFound();
			}

			return Ok(municipalDepartments);
		}
	}
}
