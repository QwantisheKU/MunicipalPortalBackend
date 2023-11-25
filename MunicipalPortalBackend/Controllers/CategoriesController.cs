using Microsoft.AspNetCore.Mvc;
using MunicipalPortalBackend.Dtos.CategoryDtos;
using MunicipalPortalBackend.Dtos.MunicipalDepartmentDtos;
using MunicipalPortalBackend.Services.Interfaces;

namespace MunicipalPortalBackend.Controllers
{
	[Route("v1/categories")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly ICategoryService _categoryService;
		public CategoriesController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		[HttpGet]
		public async Task<ActionResult<List<CategoryDto>>> GetCategories()
		{
			var categories = await _categoryService.GetAllAsync();

			if (categories == null || !categories.Any())
			{
				return NotFound();
			}

			return Ok(categories);
		}
	}
}
