using SocketDemo;

namespace Nwo.Api.Socket
{
	public class Socket: ISocket
	{
		private readonly SocketIOClient.SocketIO client = new("http://localhost:3000");

		public async Task Connect()
		{
			await client.ConnectAsync();


			client.OnConnected += (sender, args) =>
			{
				Console.WriteLine("Connected to the server");
			};

			client.OnDisconnected += (sender, args) =>
			{
				Console.WriteLine("Reconnecting...");
				client.ConnectAsync();
			};

			client.On("chat message", message =>
			{
				Console.WriteLine($"Socket Server Sent: {message}");
			});
		}

		public async Task SendMessage(string message)
		{
			await client.EmitAsync("receiveMessage", message);
		}

		public async Task Disconnect()
		{
			if (client != null && client.Connected)
			{
				await client.DisconnectAsync();
			}
		}

	}
}