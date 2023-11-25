using MunicipalPortalBackend.Dtos.NewsDtos;

namespace MunicipalPortalBackend.Services.Interfaces
{
	public interface INewsService
	{
		Task<List<NewsDto>> GetAllAsync();

		Task<NewsDto> GetByIdAsync(int id);

		bool Create(CreateNewsDto createNewsDto);
	}
}
