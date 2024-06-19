using Microsoft.AspNetCore.SignalR.Client;

namespace Watson.Mobile.Client.Services
{
	public class SignalRService
	{
		private readonly HubConnection _connection;

		public event Action<string> NoteUpdated;

		public SignalRService()
		{
			_connection = new HubConnectionBuilder()
				.WithUrl("https://localhost:58200/noteshub")
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
