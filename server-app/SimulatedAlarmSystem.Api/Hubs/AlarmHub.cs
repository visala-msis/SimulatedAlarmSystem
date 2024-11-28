namespace SimulatedAlarmSystem.Api.Hubs
{
	using Microsoft.AspNetCore.SignalR;

	public class AlarmHub : Hub
	{
		// This method will be used to send alarm data to clients
		public async Task SendAlarmData(string alarmData)
		{
			// Broadcast alarm data to all connected clients
			await Clients.All.SendAsync("ReceiveAlarmData", alarmData);
		}
	}

}
