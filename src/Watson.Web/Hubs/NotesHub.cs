using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Watson.Web.Hubs
{
	public class NotesHub : Hub
	{
		private readonly IHubContext<NotesHub> _hubContext;
		private Timer _timer;

		public NotesHub(IHubContext<NotesHub> hubContext)
		{
			_timer = new Timer(SendPing, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
			_hubContext = hubContext;
		}

		private void SendPing(object state)
		{
			_hubContext.Clients.All.SendAsync("Ping", "Ping from server");
		}

		public async Task SendNoteUpdate(string noteId)
		{
			await Clients.All.SendAsync("ReceiveNoteUpdate", noteId);
		}
	}
}
