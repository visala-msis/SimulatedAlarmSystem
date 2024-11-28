using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimulatedAlarmSystem.BL.Interfaces;
using SimulatedAlarmSystem.Models;
using System.Text.Json;

namespace SimulatedAlarmSystem.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AlarmController : ControllerBase
	{
		private readonly IAlarmService _alarmService;

		public AlarmController(IAlarmService alarmService)
		{
			_alarmService = alarmService;
		}

		[HttpGet]
		public IActionResult GetAllAlarms()
        {
			var alarms =  _alarmService.GetAlarms();
           
            return Ok(alarms);
		}

		[HttpGet("{id}")]
		public IActionResult GetAlarmById(int id)
		{
			var alarm =  _alarmService.GetAlarmById(id);
			if (alarm == null)
			{
				return NotFound();
			}
			return Ok(alarm);
		}

		[HttpPost("trigger")]
		public IActionResult TriggerAlarms()
		{
			
			var alarms= _alarmService.TriggerAlarms();
			
			return Ok(alarms);
		}
	}

}
