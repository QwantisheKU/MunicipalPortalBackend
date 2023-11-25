using MunicipalPortalBackend.Models;

namespace MunicipalPortalBackend.Repositories.Interfaces
{
	public interface IApplicationStatusRepository : IGenericRepository<ApplicationStatus>
	{
		Task<List<ApplicationStatus>> GetAllByApplicationIdAsync(int applicationId);
	}
}
