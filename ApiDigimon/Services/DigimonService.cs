using ApiDigimon.Data;
using ApiDigimon.Models;
using System.Text.Json;

namespace ApiDigimon.Services
{
	public class DigimonService
	{
		private readonly HttpClient _httpClient;
		

		public DigimonService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<DigimonResponse> GetAllAsync(int page=0, int pageSize=0)
		{
			string pages = "";
			if(pageSize > 0)
			{
				pages = $"?page={page}&pageSize={pageSize}";
			}
			var response = await _httpClient.GetAsync($"https://digi-api.com/api/v1/digimon{pages}");

			response.EnsureSuccessStatusCode();

			var content = await response.Content.ReadAsStringAsync();
			var digimons = JsonSerializer.Deserialize<DigimonResponse>(content);

			return digimons;
		}

		public async Task<List<DigimonJson>> GetContentAsync(int page = 0, int pageSize = 0)
		{
			var digimonJson = await GetAllAsync(page,pageSize);
			var digimons = digimonJson.Content;

			return digimons;
		}
	}
}
