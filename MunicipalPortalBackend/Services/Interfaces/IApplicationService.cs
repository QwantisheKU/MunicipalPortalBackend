using MunicipalPortalBackend.Dtos.ApplicationDtos;
using MunicipalPortalBackend.Models;
using Type = MunicipalPortalBackend.Models.Type;

namespace MunicipalPortalBackend.Services.Interfaces
{
	public interface IApplicationService
	{
		Task<List<ApplicationDto>> GetAllAsync(Type type);

		Task<ApplicationDto> GetByIdAsync(int id);

		bool Create(CreateApplicationDto createApplicationDto);

		bool DeleteById(int id);
	}
}
