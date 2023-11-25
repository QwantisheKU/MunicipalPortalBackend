using MunicipalPortalBackend.Models;

namespace MunicipalPortalBackend.Repositories.Interfaces
{
	public interface INewsRepository : IGenericRepository<News>
	{
		new Task<List<News>> GetAllAsync();
	}
}
