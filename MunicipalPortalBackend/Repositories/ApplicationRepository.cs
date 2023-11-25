using Microsoft.EntityFrameworkCore;
using MunicipalPortalBackend.Data;
using MunicipalPortalBackend.Models;
using MunicipalPortalBackend.Repositories.Interfaces;

namespace MunicipalPortalBackend.Repositories
{
	public class ApplicationRepository : GenericRepository<Application>, IApplicationRepository
	{
		private readonly MunicipalPortalBackendContext _context;

		public ApplicationRepository(MunicipalPortalBackendContext context) : base(context)
		{
			_context = context;
		}

		public new void DeleteById(int id)
		{
			var application = _context.Application.Find(id);
			if (application != null)
			{
				application.Status = Status.Closed;
			}
		}

		public new async Task<List<Application>> GetAllAsync()
		{
			return await _context.Application
				.Include(m => m.MunicipalDepartment)
				.Include(a => a.ApplicationStatuses)
				.ToListAsync();
		}

		public async Task<List<Application>> GetAllByDepartmentIdAsync(int municipalDepartmentId)
		{
			return await _context.Application.Where(x => x.MunicipalDepartmentId == municipalDepartmentId).ToListAsync();
		}
	}
}
