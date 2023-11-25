using AutoMapper;
using MunicipalPortalBackend.Dtos.ApplicationStatusDtos;
using MunicipalPortalBackend.Dtos.NewsDtos;
using MunicipalPortalBackend.Models;
using MunicipalPortalBackend.Repositories;
using MunicipalPortalBackend.Repositories.Interfaces;
using MunicipalPortalBackend.Services.Interfaces;

namespace MunicipalPortalBackend.Services
{
	public class NewsService : INewsService
	{
		private readonly INewsRepository _newsRepository;
		private readonly IMapper _mapper;

		public NewsService(INewsRepository newsRepository, IMapper mapper)
		{
			_newsRepository = newsRepository;
			_mapper = mapper;
		}

		public bool Create(CreateNewsDto createNewsDto)
		{
			var news = _mapper.Map<News>(createNewsDto);

			if (news == null)
			{
				return false;
			}

			try
			{
				_newsRepository.Create(news);
				_newsRepository.Save();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public async Task<List<NewsDto>> GetAllAsync()
		{
			var news = await _newsRepository.GetAllAsync();

			var mappedNews = _mapper.Map<List<NewsDto>>(news);

			return mappedNews;
		}

		public async Task<NewsDto> GetByIdAsync(int id)
		{
			var news = await _newsRepository.GetByIdAsync(id);

			var mappedNews = _mapper.Map<NewsDto>(news);

			return mappedNews;
		}
	}
}
