using System.Net.Http.Json;
using Watson.Mobile.Client.Models;

namespace Watson.Mobile.Client.Services
{
	public class NoteService
	{
		private readonly HttpClient _httpClient;
		private const string BaseUrl = "https://192.168.178.114:58200/api/v1/Note";

		public NoteService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<Note>> GetAllNotesAsync()
		{
			var response = await _httpClient.GetAsync($"{BaseUrl}/all");

			if (response.IsSuccessStatusCode)
			{
				return await response.Content.ReadFromJsonAsync<List<Note>>();
			}

			throw new HttpRequestException($"Unexpected status code: {response.StatusCode}");
		}
	}
}
