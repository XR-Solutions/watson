using Microsoft.AspNetCore.SignalR;

namespace Watson.Web.Hubs
{
	public class ObjectManipulatorHub : Hub
	{
		public void UpdateObject(string name)
		{
			//Clients.All.NotifyMessageToClients("ReceiveUpdate", );
		}
	}
}
