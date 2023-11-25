using MunicipalPortalBackend.Models;

namespace MunicipalPortalBackend.Repositories.Interfaces
{
	public interface IApplicationComplaintRepository : IGenericRepository<ApplicationComplaint>
	{
		Task<List<ApplicationComplaint>> GetAllByApplicationIdAsync(int applicationId);
	}
}
