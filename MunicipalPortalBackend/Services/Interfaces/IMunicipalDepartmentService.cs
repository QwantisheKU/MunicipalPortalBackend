using MunicipalPortalBackend.Dtos.ApplicationDtos;
using MunicipalPortalBackend.Dtos.MunicipalDepartmentDtos;

namespace MunicipalPortalBackend.Services.Interfaces
{
	public interface IMunicipalDepartmentService
	{
		Task<List<MunicipalDepartmentDto>> GetAllAsync();
	}
}
