using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Options;
using Watson.Mobile.Client.Options;

namespace Watson.Mobile.Client.Services
{
	public class SignalRService
	{
		private readonly HubConnection _connection;

		public event Action<string> NoteUpdated;

		public SignalRService(IOptions<ApiSettings> apiSettings)
		{
			_connection = new HubConnectionBuilder()
				.WithUrl($"{apiSettings.Value.BaseUrl}/noteshub")
				.Build();

			_connection.On<string>("ReceiveNoteUpdate", (noteId) =>
			{
				NoteUpdated?.Invoke(noteId);
			});
		}

		public async Task StartAsync()
		{
			await _connection.StartAsync();
		}

		public async Task StopAsync()
		{
			await _connection.StopAsync();
			await _connection.DisposeAsync();
		}
	}
}
