using MunicipalPortalBackend.Data;
using MunicipalPortalBackend.Models;
using MunicipalPortalBackend.Repositories.Interfaces;

namespace MunicipalPortalBackend.Repositories
{
	public class MunicipalDepartmentRepository : GenericRepository<MunicipalDepartment>, IMunicipalDepartmentRepository
	{
		public MunicipalDepartmentRepository(MunicipalPortalBackendContext context) : base(context)
		{
		}
	}
}
