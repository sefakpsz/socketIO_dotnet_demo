using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Nwo.Api.Socket;
using System.ComponentModel.DataAnnotations;

namespace SocketDemo.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class SocketController : ControllerBase
	{
		private readonly ISocket _socket;

		public SocketController(ISocket socket)
		{
			_socket = socket;
		}

		[HttpGet("Send Message")]
		public async Task<IActionResult> SendMessage([FromQuery][Required] string message)
		{
			await _socket.SendMessage(message);

			return Ok("Sent");
		}

		[HttpGet("Connect")]
		public async Task<IActionResult> ConnectToSocket()
		{
			await _socket.Connect();

			return Ok("Connected to the Socket.IO server");
		}

		[HttpGet("Disconnect")]
		public async Task<IActionResult> Disconnect()
		{
			await _socket.Disconnect();

			return Ok("Disconnected");
		}
	}
}