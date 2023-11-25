namespace MunicipalPortalBackend.Repositories.Interfaces
{
	public interface IGenericRepository<T> where T : class
	{
		Task<List<T>> GetAllAsync();

		Task<T> GetByIdAsync(int id);

		void Create(T entity);

		void DeleteById(int id);

		void Save();
	}
}
