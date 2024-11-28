using System.Security.Claims;
using SimulatedAlarmSystem.Models;

namespace SimulatedAlarmSystem.BL.Interfaces
{
	public interface IAlarmService
	{
		List<Alarm> GetAlarms();
		Alarm GetAlarmById(int id);
		List<String> TriggerAlarms();
	}
}
