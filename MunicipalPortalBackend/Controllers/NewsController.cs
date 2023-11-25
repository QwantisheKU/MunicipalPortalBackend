using Microsoft.AspNetCore.Mvc;
using MunicipalPortalBackend.Dtos.ApplicationDtos;
using MunicipalPortalBackend.Dtos.NewsDtos;
using MunicipalPortalBackend.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MunicipalPortalBackend.Controllers
{
	[Route("v1/news")]
	[ApiController]
	public class NewsController : ControllerBase
	{
		private readonly INewsService _newsService;

		public NewsController(INewsService newsService)
		{
			_newsService = newsService;
		}

		[HttpGet]
		public async Task<ActionResult<List<NewsDto>>> GetNews()
		{
			var news = await _newsService.GetAllAsync();

			if (news == null || !news.Any())
			{
				return NotFound();
			}

			return Ok(news);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<NewsDto>> GetNewsById([Required] int id)
		{
			var news = await _newsService.GetByIdAsync(id);

			if (news == null)
			{
				return NotFound();
			}

			return Ok(news);
		}

		[HttpPost]
		public async Task<ActionResult<bool>> CreateNews(CreateNewsDto createNewsDto)
		{
			var result = _newsService.Create(createNewsDto);

			if (result)
			{
				return Ok(result);
			}

			return BadRequest();
		}
	}
}
