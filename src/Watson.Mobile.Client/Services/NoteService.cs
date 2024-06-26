﻿using Newtonsoft.Json;
using System.Text;
using Watson.Mobile.Client.Http;
using Watson.Mobile.Client.Models;

namespace Watson.Mobile.Client.Services
{
	public class NoteService
	{
		private readonly HttpClient _httpClient;
		//private const string BaseUrl = "http://192.168.178.61/api/v1/Note";

		public NoteService()
		{
			var handler = new BypassSslValidationHandler();
			_httpClient = new HttpClient(handler)
			{
				BaseAddress = new Uri("http://192.168.30.24/")
			};
		}

		public async Task<List<Note>> GetAllNotesAsync()
		{
			HttpResponseMessage response;
			try
			{
				response = await _httpClient.GetAsync("api/v1/Note/all");
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

			if (response.IsSuccessStatusCode)
			{
				string jsonResponse = await response.Content.ReadAsStringAsync();
				Response<List<Note>> apiResponse = JsonConvert.DeserializeObject<Response<List<Note>>>(jsonResponse);

				return apiResponse.Data;
			}

			throw new HttpRequestException($"Unexpected status code: {response.StatusCode}");
		}
		
		public async Task<bool> UpdateNoteAsync(Note updatedNote)
		{
			var jsonData = JsonConvert.SerializeObject(updatedNote);
			var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var response = await _httpClient.PutAsync("api/v1/Note", content);

			if (response.IsSuccessStatusCode)
			{
				return true;
			}

			throw new HttpRequestException($"Unexpected status code: {response.StatusCode}");
		}
	}
}
