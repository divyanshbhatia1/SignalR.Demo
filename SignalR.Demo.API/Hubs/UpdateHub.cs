using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalR.Demo.API.Hubs
{
	public class UpdateHub : Hub
	{
		public async Task Send(string message)
		{
			await Clients.All.SendAsync("update", message);
		}
	}
}
