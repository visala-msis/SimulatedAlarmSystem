using SimulatedAlarmSystem.Models;

namespace SimulatedAlarmSystem.BL.Interfaces
{
	public interface IAlarmDataService
	{
		
		AlarmConfig LoadAlarmConfig();
		bool SaveAlarmConfig(AlarmConfig config);
		public IEnumerable<Alarm> LoadAlarms();

    }
}
