using Microsoft.EntityFrameworkCore;
using MunicipalPortalBackend.Data;
using MunicipalPortalBackend.Repositories.Interfaces;

namespace MunicipalPortalBackend.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		private readonly MunicipalPortalBackendContext _context;

		public GenericRepository(MunicipalPortalBackendContext context)
		{
			_context = context;
		}

		public void Create(T entity)
		{
			_context.Set<T>().Add(entity);
		}

		public void DeleteById(int id)
		{
			var entity = _context.Set<T>().Find(id);

			if (entity != null)
			{
				_context.Set<T>().Remove(entity);
			}
		}

		public async Task<List<T>> GetAllAsync()
		{
			return await _context.Set<T>().ToListAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
