using MunicipalPortalBackend.Models;

namespace MunicipalPortalBackend.Repositories.Interfaces
{
	public interface IApplicationRepository : IGenericRepository<Application>
	{
		new void DeleteById(int id);
		new Task<List<Application>> GetAllAsync();
		Task<List<Application>> GetAllByDepartmentIdAsync(int municipalDepartmentId);
	}
}
