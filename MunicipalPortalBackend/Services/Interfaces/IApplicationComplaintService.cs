using MunicipalPortalBackend.Dtos.ApplicationComplaintDtos;
using MunicipalPortalBackend.Dtos.ApplicationDtos;

namespace MunicipalPortalBackend.Services.Interfaces
{
	public interface IApplicationComplaintService
	{
		Task<List<ApplicationComplaintDto>> GetAllByApplicationIdAsync(int applicationId);

		Task<ApplicationComplaintDto> GetByIdAsync(int id);

		bool Create(int applicationId, ApplicationComplaintDto applicationComplaintDto);
	}
}
