using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using MunicipalPortalBackend.Services.Interfaces;

namespace MunicipalPortalBackend.Services
{
	public class LocationService : ILocationService
	{
		private const string cleanerDadataDomain = "https://cleaner.dadata.ru";
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IConfiguration _configuration;

		public LocationService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
		{
			_httpClientFactory = httpClientFactory;
			_configuration = configuration;
		}

		public async Task<JsonElement> CleanAddress(string[] address)
		{
			var request = new StringContent(
				JsonSerializer.Serialize(address),
				Encoding.UTF8, "application/json");

			using var httpClient = _httpClientFactory.CreateClient();
			httpClient.BaseAddress = new Uri(cleanerDadataDomain);
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", $"{_configuration["Dadata:Token"]}");
			httpClient.DefaultRequestHeaders.Add("X-Secret", $"{_configuration["Dadata:Secret"]}");

			var rawResponse = await httpClient.PostAsync("api/v1/clean/address", request);
			var stringResponse = await rawResponse.Content.ReadAsStringAsync();
			var response = JsonSerializer.Deserialize<JsonElement>(stringResponse);

			return response;
		}
	}
}
