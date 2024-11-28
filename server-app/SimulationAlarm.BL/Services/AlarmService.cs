using SimulatedAlarmSystem.BL.Interfaces;
using SimulatedAlarmSystem.Models;

namespace SimulatedAlarmSystem.Bl.Services
{
	public class AlarmService : IAlarmService
	{
		private readonly IAlarmDataService _xmlDataService;

		public AlarmService(IAlarmDataService xmlDataService)
		{
			_xmlDataService = xmlDataService;
		}

		public List<Alarm> GetAlarms()
		{
			var alarmConfig =  _xmlDataService.LoadAlarmConfig();
			return alarmConfig.Alarms.ToList();
		}

		public Alarm GetAlarmById(int id)
		{
			var alarms =  GetAlarms();
			return alarms.FirstOrDefault(a => a.Id == id);
		}

		public  List<String> TriggerAlarms()
		{
			var alarmConfig =  _xmlDataService.LoadAlarmConfig();
			var triggeredAlarms = alarmConfig.Alarms.Where(a => a.Status == "Active").ToList();
			List<String> alarmNames = new List<String>();

			// Example action: Trigger alarm if condition is met
			foreach (var alarm in triggeredAlarms)
			{
				// Logic to trigger alarm
				//if(alarm.Type=="")
				alarmNames.Add($"Triggering alarm: {alarm.Description}");
			}
			return alarmNames;
		}
	}

}
