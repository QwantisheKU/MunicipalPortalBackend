using MunicipalPortalBackend.Dtos.ApplicationDtos;
using MunicipalPortalBackend.Dtos.CategoryDtos;

namespace MunicipalPortalBackend.Services.Interfaces
{
	public interface ICategoryService
	{
		Task<List<CategoryDto>> GetAllAsync();
	}
}
