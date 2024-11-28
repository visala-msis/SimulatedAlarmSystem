using SimulatedAlarmSystem.Models;

namespace SimulatedAlarmSystem.BL.Services
{
	using SimulatedAlarmSystem.BL.Interfaces;
    using SimulatedAlarmSystem.Models.Models;
    using System.Xml.Linq;
	using System.Xml.Serialization;

	public class XmlDataService : IAlarmDataService
	{
		public  AlarmConfig LoadAlarmConfig()

		{
			string filePath = "Config/AlarmConfig.xml";
            // Deserialize XML to AlarmConfig object
            var serializer = new XmlSerializer(typeof(AlarmConfig));
			using (var reader = new StreamReader(filePath))
			{
				return (AlarmConfig)serializer.Deserialize(reader);
			}
		}
        public IEnumerable<Alarm> LoadAlarms()
        {
            string filePath = "Config/AlarmConfig.xml";
            var xdoc = XDocument.Load(filePath);
            foreach (var elem in xdoc.Descendants("Alarm"))
            {
                yield return new Alarm
                {
                    Id = (int)elem.Element("Id"),
                    Type = (string)elem.Element("Type"),
                    Status = (string)elem.Element("Status"),
                    Description = (string)elem.Element("Description"),
                    Timestamp = DateTime.Parse((string)elem.Element("Timestamp"))
                };
            }
        }
        
        public  bool SaveAlarmConfig(AlarmConfig config)
		{
            string filePath = "Config/AlarmConfig.xml";
            // Serialize AlarmConfig object to XML
            var serializer = new XmlSerializer(typeof(AlarmConfig));
			using (var writer = new StreamWriter(filePath))
			{
				serializer.Serialize(writer, config);
			}
            return true;
		}
	}

}
