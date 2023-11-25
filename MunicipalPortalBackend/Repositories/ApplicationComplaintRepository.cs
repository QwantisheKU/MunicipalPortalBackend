using Microsoft.EntityFrameworkCore;
using MunicipalPortalBackend.Data;
using MunicipalPortalBackend.Models;
using MunicipalPortalBackend.Repositories.Interfaces;

namespace MunicipalPortalBackend.Repositories
{
	public class ApplicationComplaintRepository : GenericRepository<ApplicationComplaint>, IApplicationComplaintRepository
	{
		private readonly MunicipalPortalBackendContext _context;
		public ApplicationComplaintRepository(MunicipalPortalBackendContext context) : base(context)
		{
			_context = context;
		}

		public async Task<List<ApplicationComplaint>> GetAllByApplicationIdAsync(int applicationId)
		{
			return await _context.ApplicationComplaint.Where(x => x.ApplicationId == applicationId).ToListAsync();
		}
	}
}
