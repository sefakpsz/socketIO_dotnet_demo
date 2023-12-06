namespace SocketDemo
{
	public interface ISocket
	{
		Task Connect();
		Task SendMessage(string message);
		Task Disconnect();
	}
}
