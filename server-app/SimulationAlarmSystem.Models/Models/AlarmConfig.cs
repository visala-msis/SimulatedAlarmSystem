using System.Xml.Serialization;

namespace SimulatedAlarmSystem.Models
{
	[XmlRoot("AlarmConfig")]
	public class AlarmConfig
	{
		[XmlArray("Alarms")]
		[XmlArrayItem("Alarm")]
		public List<Alarm> Alarms { get; set; } = new List<Alarm>();

		[XmlArray("Triggers")]
		[XmlArrayItem("Trigger")]
		public List<Trigger> Triggers { get; set; } = new List<Trigger>();
	}
}
