using MunicipalPortalBackend.Dtos.CategoryDtos;

namespace MunicipalPortalBackend.Dtos.NewsDtos
{
	public class NewsDto
	{
		public string Title { get; set; }

		public string Description { get; set; }

		public CategoryDto? Category { get; set; }
	}
}
