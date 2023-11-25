using MunicipalPortalBackend.Dtos.ApplicationStatusDtos;

namespace MunicipalPortalBackend.Services.Interfaces
{
	public interface IApplicationStatusService
	{
		Task<List<ApplicationStatusDto>> GetAllByApplicationIdAsync(int applicationId);

		bool Create(CreateApplicationStatusDto createApplicationStatusDto);
	}
}
