using Microsoft.EntityFrameworkCore;
using MunicipalPortalBackend.Data;
using MunicipalPortalBackend.Models;
using MunicipalPortalBackend.Repositories.Interfaces;

namespace MunicipalPortalBackend.Repositories
{
	public class NewsRepository : GenericRepository<News>, INewsRepository
	{
		private readonly MunicipalPortalBackendContext _context;

		public NewsRepository(MunicipalPortalBackendContext context) : base(context)
		{
			_context = context;
		}

		public new async Task<List<News>> GetAllAsync()
		{
			return await _context.News
				.Include(c => c.Category)
				.ToListAsync();
		}
	}
}
