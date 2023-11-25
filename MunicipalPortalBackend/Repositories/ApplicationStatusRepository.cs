using Microsoft.EntityFrameworkCore;
using MunicipalPortalBackend.Data;
using MunicipalPortalBackend.Models;
using MunicipalPortalBackend.Repositories.Interfaces;

namespace MunicipalPortalBackend.Repositories
{
	public class ApplicationStatusRepository : GenericRepository<ApplicationStatus>, IApplicationStatusRepository
	{
		private readonly MunicipalPortalBackendContext _context;

		public ApplicationStatusRepository(MunicipalPortalBackendContext context) : base(context)
		{
			_context = context;
		}

		public async Task<List<ApplicationStatus>> GetAllByApplicationIdAsync(int applicationId)
		{
			return await _context.ApplicationStatus.Where(x => x.ApplicationId == applicationId).OrderByDescending(d => d.DateCreated).ToListAsync();
		}
	}
}
