using AutoMapper;
using MunicipalPortalBackend.Dtos.CategoryDtos;
using MunicipalPortalBackend.Repositories.Interfaces;
using MunicipalPortalBackend.Services.Interfaces;

namespace MunicipalPortalBackend.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _categoryRepository;
		private readonly IMapper _mapper;

		public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
		{
			_categoryRepository = categoryRepository;
			_mapper = mapper;
		}

		public async Task<List<CategoryDto>> GetAllAsync()
		{
			var categories = await _categoryRepository.GetAllAsync();

			var mappedCategories = _mapper.Map<List<CategoryDto>>(categories);

			return mappedCategories;
		}
	}
}
