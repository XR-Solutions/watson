using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Watson.Web.Hubs
{
	public class NotesHub : Hub
	{
		public async Task SendNoteUpdate(string noteId)
		{
			await Clients.All.SendAsync("ReceiveNoteUpdate", noteId);
		}
	}
}
