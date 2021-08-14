using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR.Demo.API.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.Demo.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UpdateController : ControllerBase
	{
		private readonly IHubContext<UpdateHub> _updateHubContext;

		public UpdateController(IHubContext<UpdateHub> updateHubContext)
		{
			_updateHubContext = updateHubContext;
		}

		[HttpPost]
		public async Task<IActionResult> Update(string message)
		{
			await _updateHubContext.Clients.All.SendAsync("update", message);
			return Ok("Updated!");
		}
	}
}
