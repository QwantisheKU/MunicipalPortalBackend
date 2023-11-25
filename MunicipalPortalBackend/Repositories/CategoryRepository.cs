using MunicipalPortalBackend.Data;
using MunicipalPortalBackend.Models;
using MunicipalPortalBackend.Repositories.Interfaces;

namespace MunicipalPortalBackend.Repositories
{
	public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
	{
		public CategoryRepository(MunicipalPortalBackendContext context) : base(context)
		{
		}
	}
}
